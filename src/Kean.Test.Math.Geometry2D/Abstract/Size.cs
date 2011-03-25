﻿using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
using Kean.Core.Basis.Extension;

namespace Kean.Test.Math.Geometry2D.Abstract
{
    public abstract class Size<TransformType, TransformValue, SizeType, SizeValue, R, V> : Vector<TransformType, TransformValue, SizeType, SizeValue, SizeType, SizeValue, R, V>
        where TransformType : Kean.Math.Geometry2D.Abstract.Transform<TransformType, TransformValue, SizeType, SizeValue, R, V>, new()
        where TransformValue : struct, Kean.Math.Geometry2D.Abstract.ITransform<V>
        where SizeType : Kean.Math.Geometry2D.Abstract.Size<TransformType, TransformValue, SizeType, SizeValue, R, V>, new()
        where SizeValue : struct, Kean.Math.Geometry2D.Abstract.ISize<V>, Kean.Math.Geometry2D.Abstract.IVector<V>
        where R : Kean.Math.Abstract<R, V>, new()
        where V : struct
    {
        [Test]
        public void GetValues()
        {
            Assert.That(this.Vector0.Width, Is.EqualTo(this.Cast(22.221)).Within(this.Precision));
            Assert.That(this.Vector0.Height, Is.EqualTo(this.Cast(-3.1)).Within(this.Precision));
        }
        [Test]
        public void Swap()
        {
            SizeType result = this.Vector0.Swap();
            Assert.That(result.Width, Is.EqualTo(this.Vector0.Height));
            Assert.That(result.Height, Is.EqualTo(this.Vector0.Width));
        }
        public void Run()
        {
            this.Run(
                this.Equality,
                this.Addition,
                this.Subtraction,
                this.ScalarMultitplication,
                this.GetValues,
                this.Swap
                );
        }
    }
}
