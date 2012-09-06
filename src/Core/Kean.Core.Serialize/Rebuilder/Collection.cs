﻿// 
//  Collection.cs
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2012 Simon Mika
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
using Kean.Core;
using Kean.Core.Extension;
using Kean.Core.Reflect.Extension;
using Kean.Core.Collection.Extension;

namespace Kean.Core.Serialize.Rebuilder
{
	public class Collection :
		IRebuilder
	{
		public Collection()
		{ }
		#region IRebuilder Members
		public Data.Node Store(Storage storage, Data.Node data)
		{
			if (data is Data.Branch)
			{
				Core.Collection.IList<Data.Node> nodes = new Core.Collection.List<Data.Node>();
				foreach (Data.Node child in (data as Data.Branch).Nodes)
					if (child is Data.Collection)
						foreach (Data.Node c in (child as Data.Collection).Nodes)
							nodes.Add(c);
					else
						nodes.Add(child);
				(data as Data.Branch).Nodes.Clear();
				(data as Data.Branch).Nodes.Add(nodes);
			}
			return data;
		}
		public Data.Node Load(Storage storage, Data.Node data)
		{
			if (data is Data.Branch)
			{
				Core.Collection.IDictionary<string, Data.Node> nodes = new Core.Collection.Dictionary<string, Data.Node>((data as Data.Branch).Nodes.Count);
				foreach (Data.Node child in (data as Data.Branch).Nodes)
				{
					Data.Node n;
					if ((n = nodes[child.Name]).IsNull())
						nodes[child.Name] = child;
					else if (n is Data.Collection)
						(n as Data.Collection).Nodes.Add(child.UpdateLocators(child.Locator + "[" + (n as Data.Collection).Nodes.Count + "]"));
					else
					{
						Data.Collection collection = new Data.Collection() { Name = child.Name, Locator = child.Locator, Region = child.Region }; // TODO: include all children in region
						collection.Nodes.Add(n.UpdateLocators(n.Locator + "[0]"));
						collection.Nodes.Add(child.UpdateLocators(child.Locator + "[1]"));
						nodes[child.Name] = collection;
					}
				}
				(data as Data.Branch).Nodes.Clear();
				foreach (KeyValue<string, Data.Node> n in nodes)
					(data as Data.Branch).Nodes.Add(n.Value);
			}
			return data;
		}
		#endregion
	}
}

