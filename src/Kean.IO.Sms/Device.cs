// 
//  Device.cs
//  
//  Author:
//       Simon Mika <smika@hx.se>
//  
//  Copyright (c) 2010-2011 Simon Mika
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

namespace Kean.IO.Sms
{
	public class Device
	{
		Serial.Port port;

		public bool IsOpen { get { return this.port.NotNull() && this.port.IsOpen; } }
		public Device()
		{
		}

		public bool Open(string resource)
		{
			this.port = Serial.Port.Open(resource, "57600 8n1");
			this.port.WriteLine("AT");
			Console.WriteLine("AT");
			Console.WriteLine(this.port.Read());
			return this.IsOpen;

		}
		public void Close()
		{
			if (this.IsOpen)
				this.port.Close();
		}
		public void Send(Message message)
		{
			Console.WriteLine(this.port.Read());
			this.port.WriteLine("AT+CMGS=\"" +  message.Receiver + "\"");
			Console.WriteLine("AT+CMGS=\"" +  message.Receiver + "\"");
			this.port.WriteLine(message.Body);
			this.port.Write(0x1a);
			Console.WriteLine(this.port.Read());
		}
	}
}
