﻿using System;

namespace Kean.Xml
{
	public class Position
	{
		public int Row { get; private set; }
		public int Column { get; private set; }
		public Position(int row, int column)
		{
			this.Row = row;
			this.Column = column;
		}
	}
}
