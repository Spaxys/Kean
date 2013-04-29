﻿using System;
using Kean.Core.Extension;
using NUnit.Framework;


namespace Kean.Math.Geometry3D.Test.Abstract
{
    public abstract class Box<T, TransformType, TransformValue, BoxType, BoxValue, PointType, PointValue, SizeType, SizeValue, R, V> :
        Kean.Test.Fixture<T>
        where T : Kean.Test.Fixture<T>, new()
        where BoxType : Kean.Math.Geometry3D.Abstract.Box<TransformType, TransformValue, BoxType, BoxValue, PointType, PointValue, SizeType, SizeValue, R, V>, new()
        where BoxValue : struct, Kean.Math.Geometry3D.Abstract.IBox<PointValue, SizeValue, V>
        where TransformType : Kean.Math.Geometry3D.Abstract.Transform<TransformType, TransformValue, SizeType, SizeValue, R, V>, new()
        where TransformValue : struct, Kean.Math.Geometry3D.Abstract.ITransform<V>
        where PointType : Kean.Math.Geometry3D.Abstract.Point<TransformType, TransformValue, PointType, PointValue, SizeType, SizeValue, R, V>, new()
        where PointValue : struct, Kean.Math.Geometry3D.Abstract.IPoint<V>, Kean.Math.Geometry3D.Abstract.IVector<V>
        where SizeType : Kean.Math.Geometry3D.Abstract.Size<TransformType, TransformValue, SizeType, SizeValue, R, V>, new()
        where SizeValue : struct, Kean.Math.Geometry3D.Abstract.ISize<V>, Kean.Math.Geometry3D.Abstract.IVector<V>
        where R : Kean.Math.Abstract<R, V>, new()
        where V : struct
    {
        protected float Precision { get { return 1e-4f; } }
        protected abstract V Cast(double value);
        protected BoxType Box0 { get; set; }
        protected BoxType Box1 { get; set; }
        protected BoxType Box2 { get; set; }
        protected override void Run()
        {
            this.Run(
				this.Equality,
                this.LeftTop,
                this.Size,
                this.Hash);
        }
        #region Equality
        [Test]
        public void Equality()
        {
            BoxType box = null;
			Verify(this.Box0, Is.EqualTo(this.Box0));
			Verify(this.Box0.Equals(this.Box0 as object), Is.True);
			Verify(this.Box0 == this.Box0, Is.True);
			Verify(this.Box0 != this.Box1, Is.True);
			Verify(this.Box0 == box, Is.False);
			Verify(box == box, Is.True);
			Verify(box == this.Box0, Is.False);
        }
        #endregion
        [Test]
        public void LeftTop()
        {
            PointType leftTop = this.Box0.LeftTopFront;
			Verify(leftTop.X, Is.EqualTo(1));
			Verify(leftTop.Y, Is.EqualTo(2));
			Verify(leftTop.Z, Is.EqualTo(3));
        }
        [Test]
        public void Size()
        {
            SizeType size = this.Box0.Size;
			Verify(size.Width, Is.EqualTo(4));
			Verify(size.Height, Is.EqualTo(5));
			Verify(size.Depth, Is.EqualTo(6));
        }
        #region Arithmetic
        [Test]
        public void Addition()
        {
        }
        [Test]
        public void Subtraction()
        {
        }
        [Test]
        public void ScalarMultitplication()
        {
        }
        #endregion
        #region Hash Code
        [Test]
        public void Hash()
        {
			Verify(this.Box0.Hash(), Is.Not.EqualTo(0));
        }
        #endregion
    }
}
