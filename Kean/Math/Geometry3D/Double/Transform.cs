// 
//  Transform.cs (generated by template)
//  
//  Author:
//       Anders Frisk <andersfrisk77@gmail.com>
//  
//  Copyright (c) 2011 Anders Frisk
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
// 
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Kean.Extension;
using Kean.Math.Exception;

namespace Kean.Math.Geometry3D.Double
{
	public struct Transform :
		IEquatable<Transform>
	{
		public double A;
		public double B;
		public double C;
		public double D;
		public double E;
		public double F;
		public double G;
		public double H;
		public double I;
		public double J;
		public double K;
		public double L;
		public Transform(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l) 
		{
			this.A = a;
			this.B = b;
			this.C = c;
			this.D = d;
			this.E = e;
			this.F = f;
			this.G = g;
			this.H = h;
			this.I = i;
			this.J = j;
			this.K = k;
			this.L = l;
		}
		public double this[int x, int y]
		{
			get
			{
				double result;
				switch (x)
				{
					case 0:
						switch (y)
						{
							case 0: result = this.A; break;
							case 1: result = this.B; break;
							case 2: result = this.C; break;
							case 3: result = 0; break;
							default: throw new IndexOutOfRange();
						}
						break;
					case 1:
						switch (y)
						{
							case 0: result = this.D; break;
							case 1: result = this.E; break;
							case 2: result = this.F; break;
							case 3: result = 0; break;
							default: throw new IndexOutOfRange();
						}
						break;
					case 2:
						switch (y)
						{
							case 0: result = this.G; break;
							case 1: result = this.H; break;
							case 2: result = this.I; break;
							case 3: result = 0; break;
							default: throw new IndexOutOfRange();
						}
						break;
					case 3:
						switch (y)
						{
							case 0: result = this.J; break;
							case 1: result = this.K; break;
							case 2: result = this.L; break;
							case 3: result = 1; break;
							default: throw new IndexOutOfRange();
						}
						break;
					default: throw new IndexOutOfRange();
				}
				return result;
			}
		}
		#region Transform Properties
		public double ScalingX { get { return Math.Double.SquareRoot((Math.Double.Squared(this.A) + Math.Double.Squared(this.B) + Math.Double.Squared(this.C))); } }
		public double ScalingY { get { return Math.Double.SquareRoot((Math.Double.Squared(this.D) + Math.Double.Squared(this.E) + Math.Double.Squared(this.F))); } }
		public double ScalingZ { get { return Math.Double.SquareRoot((Math.Double.Squared(this.G) + Math.Double.Squared(this.H) + Math.Double.Squared(this.I))); } }
		public double Scaling { get { return (this.ScalingX + this.ScalingY + this.ScalingZ) / 3; } }
		public Size Translation { get { return new Size(this.J, this.K, this.L); } }
		#endregion
		public Transform Inverse
		{
			get
			{
				double determinant = this.A * (this.E * this.I - this.F * this.H) + this.D * (this.H * this.C - this.I * this.B) + this.G * (this.B * this.F - this.E * this.C);
				Transform result = new Transform()
				{
					A = (this.E * this.I - this.H * this.F) / determinant,
					B = (this.H * this.C - this.I * this.B) / determinant,
					C = (this.B * this.F - this.E * this.C) / determinant,
					D = (this.G * this.F - this.I * this.D) / determinant,
					E = (this.A * this.I - this.G * this.C) / determinant,
					F = (this.D * this.C - this.F * this.A) / determinant,
					G = (this.D * this.H - this.E * this.G) / determinant,
					H = (this.G * this.B - this.A * this.H) / determinant,
					I = (this.A * this.E - this.D * this.B) / determinant,
					J = new double(),
					K = new double(),
					L = new double()
				};
				Transform translation = result * Transform.CreateTranslation(this.J, this.K, this.L);
				result.J = -translation.J;
				result.K = -translation.K;
				result.L = -translation.L;
				return result;
			}
		}
		#region Manipulations
		public Transform Translate(double delta)
		{
			return this.Translate(delta, delta, delta);
		}
		public Transform Translate(Size delta)
		{
			return this.Translate(delta.Width, delta.Height, delta.Depth);
		}
		public Transform Translate(double xDelta, double yDelta, double zDelta)
		{
			return Transform.CreateTranslation(xDelta, yDelta, zDelta) * this;
		}
		public Transform Scale(double factor)
		{
			return this.Scale(factor, factor, factor);
		}
		public Transform Scale(Size factor)
		{
			return this.Scale(factor.Width, factor.Height, factor.Depth);
		}
		public Transform Scale(double xFactor, double yFactor, double zFactor)
		{
			return Transform.CreateScaling(xFactor, yFactor, zFactor) * this;
		}
		public Transform RotateX(double angle)
		{
			return Transform.CreateRotationX(angle) * this;
		}
		public Transform RotateY(double angle)
		{
			return Transform.CreateRotationY(angle) * this;
		}
		public Transform RotateZ(double angle)
		{
			return Transform.CreateRotationZ(angle) * this;
		}
		public Transform ReflectX()
		{
			return Transform.CreateReflectionX() * this;
		}
		public Transform ReflectY()
		{
			return Transform.CreateReflectionY() * this;
		}
		public Transform ReflectZ()
		{
			return Transform.CreateReflectionZ() * this;
		}
		#endregion
		#region Object Overrides
		public override bool Equals(object other)
		{
			return (other is Transform) && this.Equals((Transform)other);
		}
		public override int GetHashCode()
		{
			return (33* (33* (33* (33* (33 * (33 * (33 * (33 * this.A.GetHashCode() ^ this.B.GetHashCode()) ^ this.C.GetHashCode()) ^ this.D.GetHashCode()) ^ this.E.GetHashCode()) ^ this.F.GetHashCode())  ^ this.I.GetHashCode())  ^ this.J.GetHashCode()) ^ this.K.GetHashCode()) ^ this.F.GetHashCode() ;
		}
		public override string ToString()
		{
			return
				Kean.Math.Double.ToString(this.A) + ", " +
				Kean.Math.Double.ToString(this.B) + ", " +
				Kean.Math.Double.ToString(this.C) + ", " +
				Kean.Math.Double.ToString(this.D) + ", " +
				Kean.Math.Double.ToString(this.E) + ", " +
				Kean.Math.Double.ToString(this.F) + ", " +
				Kean.Math.Double.ToString(this.G) + ", " +
				Kean.Math.Double.ToString(this.H) + ", " +
				Kean.Math.Double.ToString(this.I) + ", " +
				Kean.Math.Double.ToString(this.J) + ", " +
				Kean.Math.Double.ToString(this.K) + ", " +
				Kean.Math.Double.ToString(this.L);
		}
		#endregion
		#region IEquatable<Transform> Members
		public bool Equals(Transform other)
		{
			return this.A == other.A && this.B == other.B && this.C == other.C && this.D == other.D && this.E == other.E && this.F == other.F && this.G == other.G && this.H == other.H && this.I == other.I && this.J == other.J && this.K == other.K && this.L == other.L;
		}
		#endregion
		#region Comparison Operators
		public static bool operator ==(Transform left, Transform right)
		{
			return left.Equals(right);
		}
		 public static bool operator !=(Transform left, Transform right)
		{
			return !(left == right);
		}
		#endregion
		#region Static Creators
		public static Transform Identity
		{
			get
			{
				double zero = 0;
				double one = 1;
				return new Transform() { A = one, B = zero, C = zero, D = zero, E = one, F = zero, G = zero, H = zero, I = one, J = zero, K = zero, L = zero };
			}
		}
		public static Transform CreateTranslation(Size delta)
		{
			return Transform.CreateTranslation(delta.Width, delta.Height, delta.Depth);
		}
		public static Transform CreateTranslation(double xDelta, double yDelta, double zDelta)
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = one, B = zero, C = zero, D = zero, E = one, F = zero, G = zero, H = zero, I = one, J = xDelta, K = yDelta, L = zDelta };
		}
		public static Transform CreateScaling(double xFactor, double yFactor, double zFactor)
		{
			double zero = 0;
			return new Transform() { A = xFactor, B = zero, C = zero, D = zero, E = yFactor, F = zero, G = zero, H = zero, I = zFactor, J = zero, K = zero, L = zero };
		}
		public static Transform CreateRotationX(double angle)
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = one, B = zero, C = zero, D = zero, E = Math.Double.Cosinus(angle), F = Math.Double.Sinus(angle), G = zero, H = Math.Double.Sinus(- (angle)), I = Math.Double.Cosinus(angle), J = zero, K = zero, L = zero };
		}
		public static Transform CreateRotationY(double angle)
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = Math.Double.Cosinus(angle), B = zero, C = Math.Double.Sinus(angle), D = zero, E = one, F = zero, G = Math.Double.Sinus(-(angle)), H = zero, I = Math.Double.Cosinus(angle), J = zero, K = zero, L = zero };
		}
		public static Transform CreateRotationZ(double angle)
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = Math.Double.Cosinus(angle), B = Math.Double.Sinus(angle), C = zero, D = Math.Double.Sinus(-(angle)), E = Math.Double.Cosinus(angle), F = zero, G = zero, H = zero, I = one, J = zero, K = zero, L = zero };
		}
		public static Transform CreateReflectionX()
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = -one, B = zero, C = zero, D = zero, E = one, F = zero, G = zero, H = zero, I = one, J = zero, K = zero, L = zero };
		}
		public static Transform CreateReflectionY()
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = one, B = zero, C = zero, D = zero, E = -one, F = zero, G = zero, H = zero, I = one, J = zero, K = zero, L = zero };
		}
		public static Transform CreateReflectionZ()
		{
			double zero = 0;
			double one = 1;
			return new Transform() { A = one, B = zero, C = zero, D = zero, E = one, F = zero, G = zero, H = zero, I = -one, J = zero, K = zero, L = zero };
		}
		public static Transform Create(double a, double b, double c, double d, double e, double f, double g, double h, double i, double j, double k, double l)
		{
			return new Transform() { A = a, B = b, C = c, D = d, E = e, F = f, G = g, H = h, I = i, J = j, K = k, L = l };
		}
		#endregion
		#region Arithmetic Operators
		public static Transform operator *(Transform left, Transform right)
		{
			return new Transform()
			{
				A = left.A * right.A + left.D * right.B + left.G * right.C,
				B = left.B * right.A + left.E * right.B + left.H * right.C,
				C = left.C * right.A + left.F * right.B + left.I * right.C,
				D = left.A * right.D + left.D * right.E + left.G * right.F,
				E = left.B * right.D + left.E * right.E + left.H * right.F,
				F = left.C * right.D + left.F * right.E + left.I * right.F,
				G = left.A * right.G + left.D * right.H + left.G * right.I,
				H = left.B * right.G + left.E * right.H + left.H * right.I,
				I = left.C * right.G + left.F * right.H + left.I * right.I,
				J = left.A * right.J + left.D * right.K + left.G * right.L + left.J,
				K = left.B * right.J + left.E * right.K + left.H * right.L + left.K,
				L = left.C * right.J + left.F * right.K + left.I * right.L + left.L,
			};
		}
		#endregion
		#region Casts
		public static implicit operator Transform(string value)
		{
			Transform result = new Transform();
			if (value.NotEmpty())
			{
				try
				{
					string[] values = value.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
					if (values.Length == 12)
						result = new Transform(
							Kean.Math.Double.Parse(values[0]), Kean.Math.Double.Parse(values[1]), Kean.Math.Double.Parse(values[2]),
							Kean.Math.Double.Parse(values[3]), Kean.Math.Double.Parse(values[4]), Kean.Math.Double.Parse(values[5]),
							Kean.Math.Double.Parse(values[6]), Kean.Math.Double.Parse(values[7]), Kean.Math.Double.Parse(values[8]),
							Kean.Math.Double.Parse(values[9]), Kean.Math.Double.Parse(values[10]), Kean.Math.Double.Parse(values[11]));
				}
				catch
				{
				}
			}
			return result;
		}
		public static explicit operator double[,](Transform value)
		{
			return new double[,] { 
						{ value[0, 0], value[0, 1], value[0, 2], value[0, 3] }, 
						{ value[1, 0], value[1, 1], value[1, 2], value[1, 3] }, 
						{ value[2, 0], value[2, 1], value[2, 2], value[2, 3] }, 
						{ value[3, 0], value[3, 1], value[3, 2], value[3, 3] }};
		}
		public static implicit operator string(Transform value)
		{
			return value.NotNull() ? value.ToString() : null;
		}
		public static implicit operator Transform(Integer.Transform value)
		{
			return new Transform(value.A, value.B, value.C, value.D, value.E, value.F, value.G, value.H, value.I, value.J, value.K, value.L);
		}
		public static explicit operator Integer.Transform(Transform value)
		{
			return new Integer.Transform((int)value.A, (int)value.B, (int)value.C, (int)value.D, (int)value.E, (int)value.F, (int)value.G, (int)value.H, (int)value.I, (int)value.J, (int)value.K, (int)value.L);
		}
		#endregion
	}
}
