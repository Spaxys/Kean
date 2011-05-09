﻿// 
//  PointValue.cs
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
namespace Kean.Math.Geometry2D.Single
{
    public struct PointValue :
        Abstract.IPoint<float>, Abstract.IVector<float>
    {
        float x;
        float y;
        public float X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public float Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public PointValue(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        #region Arithmetic Vector - Vector Operators
        public static PointValue operator +(PointValue left, PointValue right)
        {
            return new PointValue(left.X + right.X, left.Y + right.Y);
        }
        public static PointValue operator -(PointValue left, PointValue right)
        {
            return new PointValue(left.X - right.X, left.Y - right.Y);
        }
        public static PointValue operator -(PointValue vector)
        {
            return new PointValue(-vector.X, -vector.Y);
        }
        public static float operator *(PointValue left, PointValue right)
        {
            return left.X * right.X + left.Y * right.Y;
        }
        #endregion
        #region Arithmetic Vector and Scalar
        public void Add(float x, float y)
        {
            this.X += x;
            this.Y += y;
        }
        public void Add(ref float x, ref float y)
        {
            this.X += x;
            this.Y += y;
        }
        public void Add(PointValue other)
        {
            this.X += other.X;
            this.Y += other.Y;
        }
        public void Add(ref PointValue other)
        {
            this.X += other.X;
            this.Y += other.Y;
        }
        public void Multiply(ref float scalar)
        {
            this.X *= scalar;
            this.Y *= scalar;
        }
        public void Multiply(float scalar)
        {
            this.X *= scalar;
            this.Y *= scalar;
        }
        public static PointValue operator *(PointValue left, float right)
        {
            return new PointValue(left.X * right, left.Y * right);
        }
        public static PointValue operator *(float left, PointValue right)
        {
            return right * left;
        }
        #endregion
        #region Casts
        public static implicit operator Point(PointValue value)
        {
            return new Point(value.X, value.Y);
        }
        public static explicit operator PointValue(Point value)
        {
            return new PointValue(value.X, value.Y);
        }
        public static implicit operator PointValue(Geometry2D.Integer.PointValue value)
        {
            return new PointValue(value.X, value.Y);
        }
        public static implicit operator Geometry2D.Double.PointValue(PointValue value)
        {
            return new Geometry2D.Double.PointValue(value.X, value.Y);
        }
        public static explicit operator Geometry2D.Integer.PointValue(PointValue value)
        {
            return new Geometry2D.Integer.PointValue((int)value.X, (int)value.Y);
        }
        public static explicit operator PointValue(Geometry2D.Double.PointValue value)
        {
            return new PointValue((float)value.X, (float)value.Y);
        }
        #endregion
    }
}
