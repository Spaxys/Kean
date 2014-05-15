﻿// 
//  Model.cs
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
using Collection = Kean.Collection;
using Kean.Extension;

namespace Kean.Math.Regression.Ransac
{
	public abstract class Model<TDomain, TRange, TTransform>
	{
		public int FitsWell { get; protected set; }
		public int RequiredMeasures { get; protected set; }
		protected Model() { }
		public abstract TTransform Estimate(TDomain[] domain, TRange[] range);
		public abstract bool Fits(TTransform transform, TDomain domain, TRange range);
		public Regression.Ransac.Estimator<TDomain, TRange, TTransform> CreateEstimator(int maximumIterations, double confidence = 0.99)
		{
			return new Regression.Ransac.Estimator<TDomain, TRange, TTransform>(this, maximumIterations, confidence);
		}
	}
}
