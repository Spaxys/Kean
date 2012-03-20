﻿// 
//  Media.cs
//  
//  Author:
//       Anders Frisk <andersfrisk77@gmail.com>
//  
//  Copyright (c) 2012 Anders Frisk
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
using Collection = Kean.Core.Collection;

namespace Kean.Draw.Net.Sdp
{
    /*
        Media description, if present
        m=  (media name and transport address)
        i=* (media title)
        c=* (connection information—optional if included at
             session level)
        b=* (zero or more bandwidth information lines)
        k=* (encryption key)
        a=* (zero or more media attribute lines)
    */
    public class Media
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Connection { get; set; }
        public string Bandwidth { get; set; }
        public string EncryptionKey { get; set; }
        public Collection.List<string> Attributes { get; set; }
    }
}
