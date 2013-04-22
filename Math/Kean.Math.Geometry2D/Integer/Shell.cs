// 
//  Shell.cs (generated by template)
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2011 Simon Mika
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

namespace Kean.Math.Geometry2D.Integer
{
    public struct Shell :
		IEquatable<Shell>
    {
        public int Left;
        public int Right;
        public int Top;
        public int Bottom;
        public Point LeftTop { get { return new Point(this.Left, this.Top); } }
        public Size Size { get { return new Size(this.Left + this.Right, this.Top + this.Bottom); } }
        public Point Balance { get { return new Point(this.Right - this.Left, this.Bottom - this.Top); } }
      
		public Shell(int value) : this(value, value) { }
		public Shell(int x, int y) : this(x, x, y, y) { }
		public Shell(int left, int right, int top, int bottom)
        {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
        }
		#region Increase, Decrease
		public Box Decrease(Size size)
		{
			return new Box(this.Left, this.Top, size.Width - this.Left - this.Right, size.Height - this.Top - this.Bottom);
		}
		public Box Increase(Size size)
		{
			return  new Box(-this.Left, -this.Right, size.Width + this.Left + this.Right, size.Height + this.Top + this.Bottom);
		}
		public Box Decrease(Box  box)
		{
			return new Box(box.LeftTop.X + this.Left, box.LeftTop.Y + this.Top, box.Size.Width - this.Left - this.Right, box.Size.Height - this.Top - this.Bottom);
		}
		public Box Increase(Box box)
		{
			return new Box(box.LeftTop.X - this.Left, box.LeftTop.Y - this.Top, box.Size.Width + this.Left + this.Right, box.Size.Height + this.Top + this.Bottom);
		}
		#endregion
        #region Static Operators
        public static Size operator -(Size left, Shell right)
        {
            return new Size(left.Width - right.Left - right.Right, left.Height - right.Top - right.Bottom);
        }
        public static Size operator +(Size left, Shell right)
        {
            return new Size(left.Width + right.Left + right.Right, left.Height + right.Top + right.Bottom);
        }
        public static Shell operator +(Shell left, Shell right)
        {
            return new Shell(left.Left + right.Left, left.Right + right.Right, left.Top + right.Top, left.Bottom + right.Bottom);
        }
        public static Shell operator -(Shell left, Shell right)
        {
            return new Shell(left.Left - right.Left, left.Right - right.Right, left.Top - right.Top, left.Bottom - right.Bottom);
        }
        public static Shell Maximum(Shell left, Shell right)
        {
            return new Shell(Kean.Math.Integer.Maximum(left.Left, right.Left), Kean.Math.Integer.Maximum(left.Right, right.Right), Kean.Math.Integer.Maximum(left.Top, right.Top), Kean.Math.Integer.Maximum(left.Bottom, right.Bottom));
        }
        public static Shell Minimum(Shell left, Shell right)
        {
            return new Shell(Kean.Math.Integer.Minimum(left.Left, right.Left), Kean.Math.Integer.Minimum(left.Right, right.Right), Kean.Math.Integer.Minimum(left.Top, right.Top), Kean.Math.Integer.Minimum(left.Bottom, right.Bottom));
        }
        #endregion
        #region Comparison Operators
        /// <summary>
        /// Defines equality.
        /// </summary>
        /// <param name="Left">Point Left of operator.</param>
        /// <param name="Right">Point Right of operator.</param>
        /// <returns>True if <paramref name="Left"/> equals <paramref name="Right"/> else false.</returns>
        public static bool operator ==(Shell left, Shell right)
        {
            return left.Left == right.Left && left.Right == right.Right && left.Top == right.Top && left.Bottom == right.Bottom;
        }
        /// <summary>
        /// Defines inequality.
        /// </summary>
        /// <param name="Left">Point Left of operator.</param>
        /// <param name="Right">Point Right of operator.</param>
        /// <returns>False if <paramref name="Left"/> equals <paramref name="Right"/> else true.</returns>
        public static bool operator !=(Shell left, Shell right)
        {
            return !(left == right);
        }
        #endregion
        #region Casts
        public static implicit operator string(Shell value)
        {
            return value.NotNull() ? value.ToString() : null;
        }
        public static implicit operator Shell(string value)
        {
            Shell result = new Shell();
            if (value.NotEmpty())
            {
                try
                {
                    string[] values = value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length == 4)
                        result = new Shell(Kean.Math.Integer.Parse(values[0]), Kean.Math.Integer.Parse(values[1]), Kean.Math.Integer.Parse(values[2]), Kean.Math.Integer.Parse(values[3]));
                }
                catch
                {
                }
            }
            return result;
        }
        #endregion
        #region Object Overrides
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
        public override int GetHashCode()
        {
            return 33 * (33 * (33 * this.Left.GetHashCode() ^ this.Right.GetHashCode()) ^ this.Top.GetHashCode()) ^ this.Bottom.GetHashCode();
        }
        public override string ToString()
        {
            return Kean.Math.Integer.ToString(this.Left) + ", " + Kean.Math.Integer.ToString(this.Right) + ", " + Kean.Math.Integer.ToString(this.Top) + ", " + Kean.Math.Integer.ToString(this.Bottom);
        }
    	#endregion
    }
}