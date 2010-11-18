// 
//  List.cs
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2009 Simon Mika
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

namespace Kean.Test.Core.Collection.Base
{
	public abstract class List<L> :
		Vector<L>
		where L : Target.IList<int>, new()
	{
		public override void Run()
		{
			base.Run();
			this.AddReplaceRemove();
			this.AddReplaceRemoveTen();
			this.InsertReplaceRemove();
		}
		[Test]
		public void AddReplaceRemove()
		{
			L target = new L();
			Expect(target.Count, EqualTo(0), this.Prefix + "AddReplaceRemove.0");
			target.Add(42);
			Expect(target.Count, EqualTo(1), this.Prefix + "AddReplaceRemove.1");
			Expect(target[0], EqualTo(42), this.Prefix + "AddReplaceRemove.2");
			target[0] = 1337;
			Expect(target[0], EqualTo(1337), this.Prefix + "AddReplaceRemove.3");
			Expect(target.Remove(), EqualTo(1337), this.Prefix + "AddReplaceRemove.4");
			Expect(target.Count, EqualTo(0), this.Prefix + "AddReplaceRemove.5");
		}
		[Test]
		public void AddReplaceRemoveTen()
		{
			L target = new L();
			for (int i = 0; i < 10; i++)
			{
				Expect(target.Count, EqualTo(i), this.Prefix + "AddReplaceRemoveTen." + i);
				target.Add(42 + i);
			}
			Expect(target.Count, EqualTo(10), this.Prefix + "AddReplaceRemoveTen.10");
			for (int i = 0; i < 10; i++)
			{
				Expect(target[i], EqualTo(42 + 9 - i), this.Prefix + "AddReplaceRemoveTen." + (11 + 2 * i));
				target[i] = 1337 + i;
				Expect(target[i], EqualTo(1337 + i), this.Prefix + "AddReplaceRemoveTen." + (12 + 2 * i));
			}
			for (int i = 0; i < 10; i++)
			{
				Expect(target.Remove(), EqualTo(1337 + i), this.Prefix + "AddReplaceRemoveTen." + (30 + 2 * i));
				Expect(target.Count, EqualTo(9 - i), this.Prefix + "AddReplaceRemoveTen." + (31 + 2 * i));
			}
		}
		[Test]
		public void InsertReplaceRemove()
		{
			L target = new L();
			for (int i = 0; i < 10; i++)
			{
				Expect(target.Count, EqualTo(i), this.Prefix + "InsertReplaceRemove." + i);
				target.Add(i);
			}
			Expect(target[6], EqualTo(3), this.Prefix + "InsertReplaceRemove.10");
			target.Insert(6, 42);
			Expect(target.Count, EqualTo(11), this.Prefix + "InsertReplaceRemove.11");
			for (int i = 0; i < 6; i++)
				Expect(target[i], EqualTo(9 - i), this.Prefix + "InsertReplaceRemove." + (12 + i));
			Expect(target[6], EqualTo(42), this.Prefix + "InsertReplaceRemove.18");
			for (int i = 7; i < 10; i++)
				Expect(target[i], EqualTo(10 - i), this.Prefix + "InsertReplaceRemove." + (19 + i));
			target[6] = 1337;
			Expect(target[6], EqualTo(1337), this.Prefix + "InsertReplaceRemove.23");
			Expect(target.Remove(6), EqualTo(1337), this.Prefix + "AddReplaceRemoveTen.24");
			Expect(target.Count, EqualTo(10), this.Prefix + "InsertReplaceRemove.15");
			for (int i = 0; i < 10; i++)
				Expect(target[i], EqualTo(9 - i), this.Prefix + "InsertReplaceRemove." + (16 + i));
		}
	}
}