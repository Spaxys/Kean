// 
//  LinkedList.cs
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
using Kean.Core.Basis.Extension;
using Kean.Core.Collection.Extension;

namespace Kean.Core.Collection.Linked
{
	public class List<T> :
		List<Link<T>, T>
	{
		public List() { }
	}
	public class List<L, T> :
		Abstract.List<T>
		where L : class, ILink<L, T>, new()
	{
		L first;
		public override int Count { get { return this.first.Count<L, T>(); } }
		public override T this[int index]
		{
			get { return this.first.Get<L, T>(index); }
			set { this.first.Set<L, T>(index, value); }
		}
		#region Constructors
		public List() { }
		public List(params T[] items) :
			this()
		{
			Extension.ListExtension.Add(this, items);
		}
		#endregion
		public override void Add(T element)
		{
			this.first = new L()
			{
				Head = element,
				Tail = this.first,
			};
		}
		public override T Remove()
		{
			T result = default(T);
			if (this.first.NotNull())
			{
				result = this.first.Head;
				this.first = this.first.Tail;
			}
			return result;
		}
        public override T Remove(int index)
		{
			T result;
			this.first = this.first.Remove(index, out result);
			return result;
		}
        public override void Insert(int index, T element)
		{
			this.first = this.first.Insert(index, element);
		}
	}
}
