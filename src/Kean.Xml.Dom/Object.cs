﻿using System;
using Kean.Core.Extension;

namespace Kean.Xml.Dom
{
	public abstract class Object
	{
		public Region Region { get; internal set; }

		Document document;
		public Document Document
		{
			get { return this.document; }
			internal set { this.ChangeDocument(value); }
		}
		Element parent;
		public Element Parent
		{
			get { return this.parent; }
			internal set { this.ChangeParent(value); }
		}
		protected Object()
		{
		}
		protected virtual void ChangeDocument(Document document)
		{
			this.document = document;
		}
		protected virtual void ChangeParent(Element parent)
		{
			this.parent = parent;
			this.document = parent.NotNull() ? parent.document : null;
		}
	}
}
