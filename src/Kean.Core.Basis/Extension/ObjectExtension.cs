// 
//  Object.cs
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2010 Simon Mika
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

namespace Kean.Core.Basis.Extension
{
	public static class ObjectExtension
	{
		public static bool NotNull(this object me)
		{
			return !object.ReferenceEquals(me, null);
		}
		public static bool IsNull(this object me)
		{
			return object.ReferenceEquals(me, null);
		}
		public static bool Same(this object me, object other)
		{
			return object.ReferenceEquals(me, other);
		}
		public static bool SameOrEquals(this object me, object other)
		{
			return object.ReferenceEquals(me, other) || 
				!object.ReferenceEquals(me, null) && me.Equals(other);
		}
		public static int Hash(this object me)
		{
			return object.ReferenceEquals(me, null) ? 0 : me.GetHashCode();
		}
	}
}
