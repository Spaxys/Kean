﻿//
//  LeftParanthesis.cs
//
//  Author:
//       Simon Mika <simon@mika.se>
//
//  Copyright (c) 2014 Simon Mika
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

namespace Kean.Algebra
{
	class LeftParanthesis :
	Expression
	{
		public override int Precedence { get { return int.MaxValue; } }
		public LeftParanthesis()
		{
		}
		public override float Evaluate(params KeyValue<string, float>[] variables)
		{
			throw new NotImplementedException();
		}
		public override Expression Derive(string variable)
		{
			throw new NotImplementedException();
		}
		public override Expression Simplify()
		{
			throw new NotImplementedException();
		}
		#region Object Overrides
		public override string ToString()
		{
			return "(";
		}
		public override bool Equals(Expression other)
		{
			return other is LeftParanthesis;
		}
		public override int GetHashCode()
		{
			return typeof(LeftParanthesis).GetHashCode();
		}
		#endregion
	}
}

