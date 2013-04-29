// 
//  Point.cs (generated by template)
//  
//  Author:
//       Anders Frisk <andersfrisk77@gmail.com>
//  
//  Copyright (c) 2011-2013 Simon Mika
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
using NUnit.Framework;
using Target = Kean.Math.Geometry3D;
using Kean.Core.Extension;

namespace Kean.Math.Geometry3D.Test.Integer
{ 
	[TestFixture]
    public class Point :
        Kean.Test.Fixture<Point>
       
    {
		float Precision { get { return 1e-4f; } }
        Target.Integer.Point CastFromString(string value)
        {
            return value;
        }
        string CastToString(Target.Integer.Point value)
        {
            return value;
        }
        
           Target.Integer.Point Point0 = new Target.Integer.Point((int)22, (int)-3, (int)10);
           Target.Integer.Point Point1 = new Target.Integer.Point((int)12, (int)13, (int)20);
           Target.Integer.Point Point2 = new Target.Integer.Point((int)34, (int)10, (int)30);
		   Target.Integer.Point Point3 = new Target.Integer.Point((int)10, (int)20, (int)30);
        protected override void Run()
        {
          
            this.Run(
				this.Equality,
                this.Addition,
                this.Subtraction,
                this.ScalarMultitplication,
                this.ScalarProduct,
                this.Casting,
                this.Hash,
                this.Casts,
                this.ValueStringCasts,
                this.Norm
                );
        }
        [Test]
        public void Norm()
        {
            Verify(this.Point0.Norm, Is.EqualTo(24.3515).Within(this.Precision));
        }
		[Test]
		public void ScalarProduct()
		{
			Target.Integer.Point point = new Target.Integer.Point();
			Verify(this.Point0.ScalarProduct(point), Is.EqualTo(0).Within(this.Precision));
			Verify(this.Point0.ScalarProduct(this.Point1), Is.EqualTo(425).Within(this.Precision));
		}
		[Test]
		public void ScalarMultitplication()
		{
			Verify(this.Point0.VectorProduct(this.Point1), Is.EqualTo(-this.Point1.VectorProduct(this.Point0)));
			Verify((this.Point0.VectorProduct(this.Point1)).X, Is.EqualTo((-190)).Within(this.Precision));
			Verify((this.Point0.VectorProduct(this.Point1)).Y, Is.EqualTo((-320)).Within(this.Precision));
			Verify((this.Point0.VectorProduct(this.Point1)).Z, Is.EqualTo((322)).Within(this.Precision));
		}
		#region Equality
		[Test]
		public void Equality()
		{
			Target.Integer.Size point = new Target.Integer.Size(); point = null;
			Verify(this.Point0, Is.EqualTo(this.Point0));
			Verify(this.Point0, Is.EqualTo(this.Point0));
			Verify(this.Point0.Equals(this.Point0), Is.True);
			Verify(this.Point0.Equals(this.Point0 as object), Is.True);
			Verify(this.Point0 == this.Point0, Is.True);
			Verify(this.Point0 != this.Point1, Is.True);
			Verify(this.Point0 == point, Is.False);
			Verify(point == point, Is.True);
			Verify(point == this.Point0, Is.False);
		}
		#endregion
		#region Arithmetic
		[Test]
		public void Addition()
		{
			Verify((this.Point0.X + this.Point1.X), Is.EqualTo(this.Point2.X).Within(this.Precision));
			Verify((this.Point0.Y + this.Point1.Y), Is.EqualTo(this.Point2.Y).Within(this.Precision));
			Verify((this.Point0.Z + this.Point1.Z), Is.EqualTo(this.Point2.Z).Within(this.Precision));
		}
		[Test]
		public void Subtraction()
		{
			Target.Integer.Size size = new Target.Integer.Size(0, 0, 0);
			Target.Integer.Size result = this.Point0 - this.Point0;
			Verify(result, Is.EqualTo(size));
		}
		#endregion
		#region Hash Code
		[Test]
		public void Hash()
		{
			Verify(this.Point0.GetHashCode(), Is.Not.EqualTo(0));
		}
		#endregion
		[Test]
		public void Casting()
		{
			string value = "10, 20, 30";
			Verify(this.CastToString(this.Point3), Is.EqualTo(value));
			Verify(this.CastFromString(value), Is.EqualTo(this.Point3));
		}
		 [Test]
        public void Casts()
        {
            // integer - Integer
            Target.Integer.Point integer = new Target.Integer.Point(10, 20, 30);
            Target.Integer.Point Integer = integer;
            Verify(Integer.X, Is.EqualTo(10));
            Verify(Integer.Y, Is.EqualTo(20));
            Verify(Integer.Z, Is.EqualTo(30));
            Verify((Target.Integer.Point)Integer, Is.EqualTo(integer));
        }
		 [Test]
        public void ValueStringCasts()
        {
            string textFromValue = new Target.Integer.Point(10, 20, 30);
            Verify(textFromValue, Is.EqualTo("10, 20, 30"));
            Target.Integer.Point @integerFromText = "10 20 30";
            Verify(@integerFromText.X, Is.EqualTo(10));
            Verify(@integerFromText.Y, Is.EqualTo(20));
            Verify(@integerFromText.Z, Is.EqualTo(30));
        }
				
		
		
		

		
      }
}
