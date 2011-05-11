﻿// 
//  SizeValue.cs
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
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.using System;
using System;
using Kean.Core.Basis.Extension;

namespace Kean.Math.Geometry2D.Double
{
	public struct SizeValue :
		Abstract.ISize<double>, Abstract.IVector<double>
	{
		double width;
		double height;
        #region ISize<double>
        public double Width
		{
			get { return this.width; }
			set { this.width = value; }
		}
		public double Height
		{
			get { return this.height; }
			set { this.height = value; }
		}
        #endregion
        #region IVector<double> Members
        double Abstract.IVector<double>.X { get { return this.width; } }
        double Abstract.IVector<double>.Y { get { return this.height; } }
        #endregion
        public SizeValue(double width, double height)
		{
			this.width = width;
			this.height = height;
		}
        #region Comparison Operators
        /// <summary>
        /// Defines equality.
        /// </summary>
        /// <param name="left">Point left of operator.</param>
        /// <param name="right">Point right of operator.</param>
        /// <returns>True if <paramref name="left"/> equals <paramref name="right"/> else false.</returns>
        public static bool operator ==(SizeValue left, SizeValue right)
        {
            return left.width == right.Width && left.Height == right.Height;
        }
        /// <summary>
        /// Defines inequality.
        /// </summary>
        /// <param name="left">Point left of operator.</param>
        /// <param name="right">Point right of operator.</param>
        /// <returns>False if <paramref name="left"/> equals <paramref name="right"/> else true.</returns>
        public static bool operator !=(SizeValue left, SizeValue right)
        {
            return !(left == right);
        }
        #endregion
        #region Casts
        public static implicit operator SizeValue(Single.SizeValue value)
        {
            return new SizeValue(value.Width, value.Height);
        }
        public static implicit operator SizeValue(Integer.SizeValue value)
        {
            return new SizeValue(value.Width, value.Height);
        }
        public static explicit operator Single.SizeValue(SizeValue value)
        {
            return new Single.SizeValue((Kean.Math.Single)(value.Width), (Kean.Math.Single)(value.Height));
        }
        public static explicit operator Integer.SizeValue(SizeValue value)
        {
            return new Integer.SizeValue((Kean.Math.Integer)(value.Width), (Kean.Math.Integer)(value.Height));
        }
        public static implicit operator string(SizeValue value)
        {
            return value.NotNull() ? value.ToString() : null;
        }
        public static implicit operator SizeValue(string value)
        {
            SizeValue result = new SizeValue();
            if (value.NotEmpty())
            {
                try
                {
                    string[] values = value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length == 2)
                        result = new SizeValue(Kean.Math.Double.Parse(values[0]), Kean.Math.Double.Parse(values[1]));
                }
                catch
                {
                }
            }
            return result;
        }
        #endregion
        #region Object Overrides
        public override int GetHashCode()
        {
            return this.Width.GetHashCode() ^ this.Height.GetHashCode();
        }
        public override string ToString()
        {
            return Kean.Math.Double.ToString(this.Width) + " " + Kean.Math.Double.ToString(this.Height);
        }
        #endregion
    }
}
