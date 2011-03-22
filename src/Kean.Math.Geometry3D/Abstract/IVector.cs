﻿using System;

namespace Kean.Math.Geometry3D.Abstract
{
	public interface IVector<V>
		where V : struct
	{
		V X { get; }
		V Y { get; }
		V Z { get; }
	}
}
