﻿// 
//  Type.cs
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
using NUnit.Framework;
using Kean.Core.Reflect.Extension;

namespace Kean.Core.Reflect.Test
{
	[TestFixture]
	public class Type :
		Kean.Test.Fixture<Type>
	{
		string prefix = "Kean.Core.Reflect.Test.Type.";
		[Test]
		public void NestedClass()
		{
			string parentName = "Kean.Core.Reflect.Test:Data.ParentClass";
			string name = parentName + "+NestedClass";
			Reflect.Type type1 = name;
			Expect((string)type1.Parent, EqualTo(parentName), this.prefix + "NestedClass.0");
			Expect((string)type1, EqualTo(name), this.prefix + "NestedClass.1");
			Reflect.Type type0 = new Data.ParentClass.NestedClass().Type();
			Expect((string)type0.Parent, EqualTo(parentName), this.prefix + "NestedClass.2");
			Expect((string)type0, EqualTo(name), this.prefix + "NestedClass.3");
			Expect(type0, EqualTo(type1), this.prefix + "NestedClass.4");
		}
		[Test]
		public void GenericStructure()
		{
			string name = "Kean.Core:KeyValue<string,object>";
			Reflect.Type type = name;
			Expect(type.Assembly, EqualTo("Kean.Core"), this.prefix + "GenericStructure.0");
			Expect(type.Name, EqualTo("Kean.Core.KeyValue"), this.prefix + "GenericStructure.1");
			//Expect(type.Arguments.Count, EqualTo(2), this.prefix + "GenericStructure.2");
			//Expect((string)type.Arguments[0], EqualTo("string"), this.prefix + "GenericStructure.3");
			//Expect((string)type.Arguments[1], EqualTo("object"), this.prefix + "GenericStructure.4");
			Expect((string)type, EqualTo(name), this.prefix + "GenericStructure.5");
			Expect(type.Category, EqualTo(TypeCategory.Structure), this.prefix + "GenericStructure.6");
		}

		protected override void Run()
		{
			this.Run(
				this.NestedClass,
				this.GenericStructure
				);
		}
	}
}
