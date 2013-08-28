// 
//  IStorage.cs
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2013 Simon Mika
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
using Collection = Kean.Core.Collection;
using Kean.Core.Collection.Extension;
using Uri = Kean.Core.Uri;
using Kean.Core.Reflect.Extension;

namespace Kean.Core.Serialize
{
	public interface IStorage
	{
		Casing Casing { get; }
		Resolver Resolver { get; }
		Data.Node Serialize(Reflect.Type type, object data, Uri.Locator locator);
		bool DeserializeContent(Serialize.Data.Node node, object result);
		void Deserialize(Serialize.Data.Node node, Reflect.Type type, Action<object> set);
	}
}