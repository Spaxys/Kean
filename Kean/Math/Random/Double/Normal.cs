//
//  Uniform.cs
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

namespace Kean.Math.Random.Double
{
	public class Normal :
		Random.Normal<double>
	{
		public Normal() : this(0, 1) { }
		public Normal(double mean, double deviation) :
			base(mean, deviation)
		{ }
		public override double Generate()
		{
			ulong x1;
			do
				x1 = this.Next();
			while (x1 == 0);
			ulong x2;
			do
				x2 = this.Next();
			while (x2 == 0);
			return this.Mean + this.Deviation * Kean.Math.Double.SquareRoot(-2 * Kean.Math.Double.Logarithm((double) x1 / ulong.MaxValue)) * Kean.Math.Double.Cosinus(2 * Kean.Math.Double.PI * (double) x2 / ulong.MaxValue);
		}
	}
}