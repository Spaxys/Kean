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
using Kean.Core.Extension;

namespace Kean.Math.Geometry2D.Single
{
	public struct SizeValue :
		Abstract.ISize<float>, Abstract.IVector<float>
	{
        public float Width;
        public float Height;
        #region ISize<float>
        float Abstract.ISize<float>.Width { get { return this.Width; } }
        float Abstract.ISize<float>.Height { get { return this.Height; } }
        #endregion
        #region IVector<float> Members
        float Abstract.IVector<float>.X { get { return this.Width; } }
        float Abstract.IVector<float>.Y { get { return this.Height; } }
        #endregion
        public float Area { get { return this.Width * this.Height; } }
        public bool IsEmpty { get { return this.Width == 0 || this.Height == 0; } }
        public SizeValue(float width, float height)
        {
            this.Width = width;
            this.Height = height;
        }
        #region Static Operators
        public static SizeValue operator -(SizeValue left, SizeValue right)
        {
            return new SizeValue(left.Width - right.Width, left.Height - right.Height);
        }
        public static SizeValue operator +(SizeValue left, SizeValue right)
        {
            return new SizeValue(left.Width + right.Width, left.Height + right.Height);
        }
        public static SizeValue Maximum(SizeValue left, SizeValue right)
        {
            return new SizeValue(Kean.Math.Single.Maximum(left.Width, right.Width), Kean.Math.Single.Maximum(left.Height, right.Height));
        }
        public static SizeValue Minimum(SizeValue left, SizeValue right)
        {
            return new SizeValue(Kean.Math.Single.Minimum(left.Width, right.Width), Kean.Math.Single.Minimum(left.Height, right.Height));
        }
        #endregion
        #region Comparison Operators
        /// <summary>
        /// Defines equality.
        /// </summary>
        /// <param name="Left">Point Left of operator.</param>
        /// <param name="Right">Point Right of operator.</param>
        /// <returns>True if <paramref name="Left"/> equals <paramref name="Right"/> else false.</returns>
        public static bool operator ==(SizeValue left, SizeValue right)
        {
            return left.Width == right.Width && left.Height == right.Height;
        }
        /// <summary>
        /// Defines inequality.
        /// </summary>
        /// <param name="Left">Point Left of operator.</param>
        /// <param name="Right">Point Right of operator.</param>
        /// <returns>False if <paramref name="Left"/> equals <paramref name="Right"/> else true.</returns>
        public static bool operator !=(SizeValue left, SizeValue right)
        {
            return !(left == right);
        }
        public static bool operator <(SizeValue left, SizeValue right)
        {
            return left.Width < right.Width && left.Height < right.Height;
        }
        public static bool operator >(SizeValue left, SizeValue right)
        {
            return left.Width > right.Width && left.Height > right.Height;
        }
        public static bool operator <=(SizeValue left, SizeValue right)
        {
            return left.Width <= right.Width && left.Height <= right.Height;
        }
        public static bool operator >=(SizeValue left, SizeValue right)
        {
            return left.Width >= right.Width && left.Height >= right.Height;
        }
        #endregion
        #region Casts
        public static implicit operator SizeValue(Integer.SizeValue value)
        {
            return new SizeValue(value.Width, value.Height);
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
					result = (SizeValue)(Size)value;   
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
			return this.ToString(true);
		}
		public string ToString(bool commaSeparated)
		{
			return ((Size)this).ToString(commaSeparated);
		}
        #endregion
    }
}
