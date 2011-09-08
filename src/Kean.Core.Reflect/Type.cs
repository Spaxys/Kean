// 
//  TypeName.cs
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

using Kean.Core.Extension;
using Kean.Core.Collection.Extension;

namespace Kean.Core.Reflect
{
	public class Type :
		System.IEquatable<Type>,
		System.IEquatable<string>,
		System.IEquatable<System.Type>
	{
		public string Assembly { get; private set; }
		public string Name { get; private set; }
		Collection.IList<Type> arguments;
		public Collection.IReadOnlyVector<Type> Arguments { get; private set; }

		System.Type type;
		#region Constructors
		Type()
		{
			this.arguments = new Collection.List<Type>();
            this.Arguments = new Collection.Wrap.ReadOnlyVector<Type>(this.arguments);
		}
		Type(System.Type type) :
			this()
		{
			this.Name = type.Namespace + "." + type.Name.Split(new char[] { '`' }, 2) [0];
			this.Assembly = type.Assembly.GetName().Name;
			if (type.IsGenericType)
				foreach (System.Type t in type.GetGenericArguments())
					this.arguments.Add(t);
		}
		Type(string name) :
			this()
		{
			int pointer = -1;
			while (++pointer < name.Length)
				switch (name [pointer])
				{
				default:
					this.Name += name [pointer];
					break;
				case '<':
					pointer++;
					int tail = name.Length;
					while (name[--tail] != '>')
						;
					foreach (string argument in name.Substring(pointer, tail - pointer).Split(','))
						this.arguments.Add(new Type(argument.Trim(' ')));
					pointer = tail;
					break;
				case ':':
					this.Assembly = this.Name;
					this.Name += '.';
					break;
				case ' ':
					this.Assembly = name.Substring(pointer + 1).Trim();
					pointer = name.Length;
					break;
				}
			string assembly = "mscorlib";
			switch (this.Name)
			{
				// http://msdn.microsoft.com/en-US/library/ya5y69ds%28v=VS.80%29.aspx
				case "bool": this.Name = "System.Boolean"; break;
				case "byte": this.Name = "System.Byte";	break;
				case "sbyte": this.Name = "System.SByte"; break;
				case "char": this.Name = "System.Char";	break;
				case "short": this.Name = "System.Int16"; break;
				case "ushort": this.Name = "System.Uint16";	break;
				case "int":	this.Name = "System.Int32";	break;
				case "uint": this.Name = "System.UInt32"; break;
				case "long": this.Name = "System.Int64"; break;
				case "ulong": this.Name = "System.UInt64"; break;
				case "float": this.Name = "System.Single"; break;
				case "double": this.Name = "System.Double";	break;
				case "decimal":	this.Name = "System.Decimal"; break;
				case "string": this.Name = "System.String";	break;
				case "object": this.Name = "System.Object";	break;
				default: assembly = this.Assembly; break;
			}
			this.Assembly = assembly;
		}
		public Type(string assembly, string name, params Type[] arguments) :
			this()
		{
			this.Assembly = assembly;
			this.Name = name;
			this.arguments.Add(arguments);
		}
		#endregion

		public T Create<T>()
		{
			return (T)this.Create();
		}
		public object Create()
		{
			return System.Activator.CreateInstance(this);
		}

		#region Implemented Interfaces
		public bool Implements<T>()
		{
			return this.GetImplementation<T>().NotNull();
		}
		public Type GetImplementation<T>()
		{
			return ((System.Type)this).GetInterface(typeof(T).Name);
		}
		#endregion
		#region Inherited Classes
		public Type Base { get { return ((System.Type)this).BaseType.NotNull() ? ((Type)((System.Type)this).BaseType) : null; } }
		public bool Inherits<T>()
		{
			return this == typeof(T) || ((System.Type)this).BaseType.NotNull() && ((Type)((System.Type)this).BaseType).Inherits<T>();
		}
		#endregion
		#region Get Attributes
		public System.Attribute[] GetAttributes()
		{
			return ((System.Type)this).GetCustomAttributes(true).Map(attribute => attribute as System.Attribute);
		}
		public T[] GetAttributes<T>()
			where T : System.Attribute
		{
			return ((System.Type)this).GetCustomAttributes(typeof(T), true).Map(attribute => attribute as T);
		}
		#endregion
		#region Object Overrides
		public override string ToString()
		{
			return this;
		}
		public override bool Equals(object other)
		{
			return base.Equals(other);
		}
		public override int GetHashCode()
		{
			return ((string)this).GetHashCode();
		}

		#endregion
		#region IEquatable<Typename>, IEquatable<string>, IEquatable<Type>
		public bool Equals(Type other)
		{
			return other.NotNull() && (string)this == (string)other;
		}
		public bool Equals(string other)
		{
			return this == other;
		}
		public bool Equals(System.Type other)
		{
			return other.NotNull() && this == (Type)other;
		}

		#endregion
		#region Binary Operators
		public static bool operator ==(Type left, Type right)
		{
			return left.Same(right) || left.NotNull() && left.Equals(right);
		}
		public static bool operator !=(Type left, Type right)
		{
			return !(left == right);
		}
		public static bool operator ==(Type left, string right)
		{
			return left.Same(right) || left.NotNull() && left.Equals(right);
		}
		public static bool operator !=(Type left, string right)
		{
			return !(left == right);
		}
		public static bool operator ==(string left, Type right)
		{
			return right == left;
		}
		public static bool operator !=(string left, Type right)
		{
			return !(left == right);
		}
		public static bool operator ==(Type left, System.Type right)
		{
			return left.Same(right) || left.NotNull() && left.Equals(right);
		}
		public static bool operator !=(Type left, System.Type right)
		{
			return !(left == right);
		}
		public static bool operator ==(System.Type left, Type right)
		{
			return right == left;
		}
		public static bool operator !=(System.Type left, Type right)
		{
			return !(left == right);
		}
		#endregion
		#region Casts
		public static implicit operator Type(string value)
		{
			return new Type(value);
		}
		public static implicit operator string(Type value)
		{
			string result = "";
			// http://msdn.microsoft.com/en-US/library/ya5y69ds%28v=VS.80%29.aspx
			switch (value.Name)
			{
			case "System.Boolean": result = "bool"; break;
			case "System.Byte": result = "byte"; break;
			case "System.SByte": result = "sbyte"; break;
			case "System.Char":	result = "char"; break;
			case "System.Decimal": result = "decimal"; break;
			case "System.Int16": result = "short"; break;
			case "System.Uint16": result = "ushort"; break;
			case "System.Int32": result = "int"; break;
			case "System.UInt32": result = "uint"; break;
			case "System.Int64": result = "long"; break;
			case "System.UInt64": result = "ulong";	break;
			case "System.Single": result = "float";	break;
			case "System.Double": result = "double"; break;
			case "System.String": result = "string"; break;
			case "System.Object": result = "object"; break;
			default:
				System.Text.StringBuilder resultBuilder = null;
				if (value.Arguments.Count > 0)
				{
					resultBuilder = new System.Text.StringBuilder().Append("<");
					bool first = true;
					foreach (System.Type name in value.Arguments)
					{
						if (!first)
							resultBuilder.Append(",");
						else
							first = false;
						resultBuilder.Append(name.FullName);
					}
					resultBuilder.Append(">");
				}

				if (value.Name.StartsWith(value.Assembly))
					resultBuilder = new System.Text.StringBuilder(value.Assembly + ":" + value.Name.Substring(value.Assembly.Length + 1)).Append(resultBuilder);
				else
				{
					resultBuilder = new System.Text.StringBuilder(value.Name).Append(resultBuilder);
					if (value.Assembly.NotEmpty() && value.Assembly != "mscorlib")
						resultBuilder.AppendFormat(" {0}", value.Assembly);
				}
				result = resultBuilder.ToString();
				break;
			}
			return result;
		}
		public static implicit operator Type(System.Type value)
		{
			return new Type(value);
		}
		public static implicit operator System.Type(Type value)
		{
			if (value.type.IsNull())
			{
				System.Text.StringBuilder name = new System.Text.StringBuilder(value.Name);
				if (value.Arguments.Count > 0)
				{
					name = name.AppendFormat("`{0}[", value.Arguments.Count);
					bool first = true;
					foreach (Type argument in value.Arguments)
					{
						if (first)
							first = false;
						else
							name.Append(",");
						name.AppendFormat("[{0}]", ((System.Type)argument).AssemblyQualifiedName);
					}
					name.Append("]");
				}
				if (value.Assembly.NotEmpty() && value.Assembly != "mscorlib")
					name.AppendFormat(", {0}", value.Assembly);
				value.type = System.Type.GetType(name.ToString(), false);
			}
			return value.type;
		}
		#endregion
	}
}