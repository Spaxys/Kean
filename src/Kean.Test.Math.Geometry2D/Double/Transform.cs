﻿using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Target = Kean.Math.Geometry2D;
namespace Kean.Test.Math.Geometry2D.Double
{
    [TestFixture]
    public class Transform :
        Kean.Test.Math.Geometry2D.Abstract.Transform<Target.Double.Transform, Target.Double.TransformValue, Target.Double.Point, Target.Double.PointValue, Target.Double.Size, Target.Double.SizeValue,
        Kean.Math.Double, double>
    {
        protected override Target.Double.Transform CastFromString(string value)
        {
            return (Target.Double.Transform)value;
        }
        protected override string CastToString(Target.Double.Transform value)
        {
            return (string)value;
        }
        [TestFixtureSetUp]
        public virtual void FixtureSetup()
        {
            this.Transform0 = new Target.Double.Transform(1, 4, 2, 5, 3, 6);
            this.Transform1 = new Target.Double.Transform(7, 4, 2, 5, 7, 6);
            this.Transform2 = new Target.Double.Transform(15, 48, 12, 33, 22, 64);
            this.Transform3 = new Target.Double.Transform(-5 / 3.0f, 4 / 3.0f, 2 / 3.0f, -1 / 3.0f, 3 / 3.0f, -6 / 3.0f);
         
            this.Point0 = new Target.Double.Point(-7, 3);
            this.Point1 = new Target.Double.Point(2, -7);
            this.Size0 = new Target.Double.Size(10, 10);

        }
        protected override double Cast(double value)
        {
            return (double)value;
        }
        [Test]
        public void Casts()
        {
            // integer - double
            {
                Target.Integer.Transform integer = new Target.Integer.Transform(10, 20, 30, 40,50, 60);
                Target.Double.Transform @double = integer;
                Expect(@double.A, Is.EqualTo(10));
                Expect(@double.B, Is.EqualTo(20));
                Expect(@double.C, Is.EqualTo(30));
                Expect(@double.D, Is.EqualTo(40));
                Expect(@double.E, Is.EqualTo(50));
                Expect(@double.F, Is.EqualTo(60));
                Expect((Target.Integer.Transform)@double, Is.EqualTo(integer));
            }
            {
                Target.Single.Transform single = new Target.Single.Transform(10, 20, 30, 40, 50, 60);
                Target.Double.Transform @double = single;
                Expect(@double.A, Is.EqualTo(10));
                Expect(@double.B, Is.EqualTo(20));
                Expect(@double.C, Is.EqualTo(30));
                Expect(@double.D, Is.EqualTo(40));
                Expect(@double.E, Is.EqualTo(50));
                Expect(@double.F, Is.EqualTo(60));
                Expect((Target.Single.Transform)@double, Is.EqualTo(single));
            }
        }
        [Test]
        public void ValueCasts()
        {
            // integer - double
            {
                Target.Integer.TransformValue integer = new Target.Integer.TransformValue(10, 20, 30, 40, 50, 60);
                Target.Double.TransformValue @double = integer;
                Expect(@double.A, Is.EqualTo(10));
                Expect(@double.B, Is.EqualTo(20));
                Expect(@double.C, Is.EqualTo(30));
                Expect(@double.D, Is.EqualTo(40));
                Expect(@double.E, Is.EqualTo(50));
                Expect(@double.F, Is.EqualTo(60));
                Expect((Target.Integer.TransformValue)@double, Is.EqualTo(integer));
            }
            {
                Target.Single.TransformValue single = new Target.Single.TransformValue(10, 20, 30, 40, 50, 60);
                Target.Double.TransformValue @double = single;
                Expect(@double.A, Is.EqualTo(10));
                Expect(@double.B, Is.EqualTo(20));
                Expect(@double.C, Is.EqualTo(30));
                Expect(@double.D, Is.EqualTo(40));
                Expect(@double.E, Is.EqualTo(50));
                Expect(@double.F, Is.EqualTo(60));
                Expect((Target.Single.TransformValue)@double, Is.EqualTo(single));
            }
        }
        [Test]
        public void ValueStringCasts()
        {
            string textFromValue = new Target.Single.TransformValue(10, 20, 30, 40, 50, 60);
            Expect(textFromValue, Is.EqualTo("10, 30, 50; 20, 40, 60; 0, 0, 1"));
            Target.Single.TransformValue @integerFromText = "10, 30, 50; 20, 40, 60; 0, 0, 1";
            Expect(@integerFromText.A, Is.EqualTo(10));
            Expect(@integerFromText.B, Is.EqualTo(20));
            Expect(@integerFromText.C, Is.EqualTo(30));
            Expect(@integerFromText.D, Is.EqualTo(40));
            Expect(@integerFromText.E, Is.EqualTo(50));
            Expect(@integerFromText.F, Is.EqualTo(60));
        }
        public void Run()
        {
            this.Run(
                this.Casts,
                this.ValueCasts,
                this.ValueStringCasts,
                base.Run
                );
        }
        public static void Test()
        {
            Transform fixture = new Transform();
            fixture.FixtureSetup();
            fixture.Run();
        }
    }
}
