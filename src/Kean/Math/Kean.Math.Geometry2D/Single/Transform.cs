﻿// 
//  Transform.cs
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
using Kean.Core.Extension;

namespace Kean.Math.Geometry2D.Single
{
	public class Transform : 
		Abstract.Transform<Transform, TransformValue, Shell, ShellValue, Box, BoxValue, Point, PointValue, Size, SizeValue, Kean.Math.Single, float>
    {
        public Transform() { }
        public Transform(float a, float b, float c, float d, float e, float f) : base(a, b, c, d, e, f) { }
        public override TransformValue Value { get { return (TransformValue)this; } }
        #region Casts
        public static implicit operator Transform(Integer.Transform value)
        {
            return value.IsNull() ? null : new Transform(value.A, value.B, value.C, value.D, value.E, value.F);
        }
        public static explicit operator Integer.Transform(Transform value)
        {
			return value.IsNull() ? null : new Integer.Transform((Kean.Math.Integer)(value.A), (Kean.Math.Integer)(value.B), (Kean.Math.Integer)(value.C), (Kean.Math.Integer)(value.D), (Kean.Math.Integer)(value.E), (Kean.Math.Integer)(value.F));
        }
        public static implicit operator Transform(TransformValue value)
        {
			return value.IsNull() ? null : new Transform(value.A, value.B, value.C, value.D, value.E, value.F);
        }
        public static explicit operator TransformValue(Transform value)
        {
			return value.IsNull() ? null : new TransformValue(value.A, value.B, value.C, value.D, value.E, value.F);
        }
        public static implicit operator string(Transform value)
        {
            return value.NotNull() ? value.ToString() : null;
        }
        public static implicit operator Transform(string value)
        {
            Transform result = null;
            if (value.NotEmpty())
            {
                try
                {
                    string[] values = value.Split(new char[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length == 6)
                        result = new Transform(Kean.Math.Single.Parse(values[0]), Kean.Math.Single.Parse(values[1]), Kean.Math.Single.Parse(values[2]), Kean.Math.Single.Parse(values[3]), Kean.Math.Single.Parse(values[4]), Kean.Math.Single.Parse(values[5]));
                }
                catch
                {
                    result = null;
                }
            }
            return result;
        }
		public static explicit operator byte[](Transform value)
		{
			int size = sizeof(float);
			byte[] result = new byte[6 * size];
			for (int x = 0; x < 3; x++)
				for (int y = 0; y < 2; y++)
					Array.Copy(value[x, y].AsBinary(), 0, result, (x + y * 3) * size, size);
			return result;
		}
		#endregion
    }
}