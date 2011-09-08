﻿// 
//  Property.cs
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
using Kean.Core;
using Kean.Core.Extension;
using Kean.Core.Reflect.Extension;
using Reflect = Kean.Core.Reflect;
using Collection = Kean.Core.Collection;
using Kean.Core.Collection.Extension;

namespace Kean.Cli.Processor
{
	class Property :
		Member
	{
		protected override char Delimiter { get { return ' '; } }
		Reflect.Property backend;
		Parameter.Abstract parameter;
		public string Value
		{
			get { return this.parameter.AsString(this.backend.Data); }
			set { this.backend.Data = this.parameter.FromString(value); }
		}
		public Property(PropertyAttribute attribute, Reflect.Property backend, Object parent) :
			base(attribute, backend, parent)
		{
			this.backend = backend;
			this.parameter = Parameter.Abstract.Create(backend);

			NotifyAttribute[] attributes = this.backend.GetAttributes<NotifyAttribute>();
			if (attributes.Length == 1)
				this.Parent.GetProperty(attributes[0].Name);
		}
		public override bool Execute(Editor editor, string[] parameters)
		{
			if (parameters.Length > 0)
				this.Value = string.Join(" ", parameters).Trim();
			if (this.backend.Readable)
				editor.Answer(this, this.Value);
			return true;
		}
		public override string Complete(string[] parameters)
		{
			return this.backend.Writable && parameters.Length > 0 ? this.parameter.Complete(string.Join(" ", parameters)) : "" ;
		}
		public override string Help(string[] parameters)
		{
			return parameters.Length > 0 ? this.parameter.Help(string.Join(" ", parameters)) : this.Usage + "\n";
		}
	}
}