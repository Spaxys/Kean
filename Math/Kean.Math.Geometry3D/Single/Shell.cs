// 
//  Shell.cs (generated by template)
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2011.2013 Simon Mika
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
using Kean.Core.Extension;

namespace Kean.Math.Geometry3D.Single
{
    public struct Shell 
    {
		public float Left;
		public float Right;
		public float Top;
		public float Bottom;
		public float Front;
		public float Back;
		public Point LeftTopFront { get { return new Point(this.Left, this.Top,this.Front); } }
		public Size Size { get { return new Size(this.Left + this.Right, this.Top + this.Bottom, this.Front+this.Back); } }
		public Point Balance { get { return new Point(this.Right - this.Left, this.Bottom - this.Top, this.Back-this.Front); } }

		//public Shell(float value) : this(value, value) { }
		//public Shell(float x, float y, float z) : this(x, x, y, y, z, z) { }

        public Shell(float left, float right, float top, float bottom, float front, float back) 
			{
				this.Left = left;
				this.Right = right;
				this.Top = top;
				this.Bottom = bottom;
				this.Front = front;
				this.Back = back;
		    }
        public Box Decrease(Size size)
          {
              return new Box(this.Left, this.Top, this.Front, size.Width - this.Left - this.Right, size.Height - this.Top - this.Bottom, size.Depth - this.Front - this.Back);
          }
          public Box Increase(Size size)
          {
              return new Box(-this.Left, -this.Right, -this.Front, size.Width + this.Left + this.Right, size.Height + this.Top + this.Bottom, size.Depth + this.Front + this.Back);
          }
		  #region Comparison Operators
		  public static bool operator ==(Shell left, Shell right)
		  {
			  return object.ReferenceEquals(left, right) ||
				  !object.ReferenceEquals(left, null) && !object.ReferenceEquals(right, null) &&
				  left.Left == right.Left &&
				  left.Right == right.Right &&
				  left.Top == right.Top &&
				  left.Bottom == right.Bottom &&
				  left.Front == right.Front &&
				  left.Back == right.Back;


		  }
		  public static bool operator !=(Shell left, Shell right)
		  {
			  return !(left == right);
		  }
		  #endregion
		  #region Object Overrides
		  /// <summary>
		  /// Return true if this object and <paramref name="other">other</paramref> are equal.
		  /// </summary>
		  /// <param name="other">Object to compare with</param>
		  /// <returns>True if this object and <paramref name="other">other</paramref> are equal else false.</returns>
		  public override bool Equals(object other)
		  {
			  return (other is Shell) && this.Equals((Shell)other);
		  }
		  /// <summary>
		  /// Return true if this object and <paramref name="other">other</paramref> are equal.
		  /// </summary>
		  /// <param name="other">Object to compare with</param>
		  /// <returns>True if this object and <paramref name="other">other</paramref> are equal else false.</returns>
		  public bool Equals(Shell other)
		  {
			  return this == other;
		  }
		  /// <summary>
		  /// Returns a hash code for this instance.
		  /// </summary>
		  /// <returns>Hash code for this instance.</returns>
		  public override int GetHashCode()
		  {
			  return 33 * (33 * (33 * (33 * (33 * this.Left.GetHashCode() ^ this.Right.GetHashCode()) ^ this.Top.GetHashCode()) ^ this.Bottom.GetHashCode()) ^ this.Front.GetHashCode()) ^ this.Back.GetHashCode();
		  }
		  public override string ToString()
		  {
			  return this.ToString("{0}, {1}, {2}, {3}, {4}, {5}");
		  }
		  public string ToString(string format)
		  {
			  return string.Format(format, (this.Left).ToString(), (this.Right).ToString(), (this.Top).ToString(), (this.Bottom).ToString(), (this.Front).ToString(), (this.Back).ToString());
		  }
		  #endregion
		  public static Shell Create(float left, float right, float top, float bottom, float front, float back)
		  {
			  Shell result = new Shell();
			  result.Left = left;
			  result.Right = right;
			  result.Top = top;
			  result.Bottom = bottom;
			  result.Front = front;
			  result.Back = back;
			  return result;
		  }
        #region Casts
		 public static implicit operator Shell(string value)
          {
              Shell result = new Shell();
              if (value.NotEmpty())
              {

                  try
                  {
                      string[] values = value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                      if (values.Length == 6)
                          result = new Shell(Kean.Math.Single.Parse(values[0]), Kean.Math.Single.Parse(values[1]), Kean.Math.Single.Parse(values[2]), Kean.Math.Single.Parse(values[3]), Kean.Math.Single.Parse(values[4]), Kean.Math.Single.Parse(values[5]));
                  }
                  catch
                  {
                  }
              }
              return result;
          }
		  public static implicit operator string(Shell value)
          {
              return value.NotNull() ? value.ToString() : null;
          }
        
		   public static implicit operator Shell(Integer.Shell value)
          {
              return new Shell(value.Left, value.Right, value.Top, value.Bottom, value.Front, value.Back);
          }
          public static explicit operator Integer.Shell(Shell value)
          {
              return new Integer.Shell((Kean.Math.Integer)(value.Left), (Kean.Math.Integer)(value.Right), (Kean.Math.Integer)(value.Top), (Kean.Math.Integer)(value.Bottom), (Kean.Math.Integer)(value.Front), (Kean.Math.Integer)(value.Back));
          }
		
		
		
        #endregion
    }
}
