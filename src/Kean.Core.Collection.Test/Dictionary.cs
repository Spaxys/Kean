// 
//  Dictionary.cs
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
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Target = Kean.Core.Collection;

namespace Kean.Core.Collection.Test
{
	[TestFixture]
	public class Dictionary :
		Base.Dictionary<Dictionary, Target.Dictionary<string, int>>
	{
		public Dictionary()
		{
			this.Prefix = "Kean.Core.Collection.Test.Dictionary.";
		}
		protected override Target.Dictionary<string, int> Create (int size)
		{
			return new Target.Dictionary<string, int>(size);
		}
	}
}

