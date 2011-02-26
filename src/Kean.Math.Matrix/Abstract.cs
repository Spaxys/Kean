﻿using System;
using Geometry2D = Kean.Math.Geometry2D;

namespace Kean.Math.Matrix
{
    public class Abstract<MatrixType, R, V> :
        IEquatable<MatrixType>
        where MatrixType : Abstract<MatrixType, R, V>, new()
        where R : Kean.Math.Abstract<R, V>, new()
        where V : struct
    {
        public Geometry2D.Integer.Size Dimensions { get; private set; }
        // Matrix elements are supposed to be in column major order 
        V[] elements;
        #region Constructors
        protected Abstract() { }
        protected Abstract(Integer order) : this(order, order) { }
        protected Abstract(Integer width, Integer height) : this(new Geometry2D.Integer.Size(width, height)) { }
        protected Abstract(Geometry2D.Integer.Size dimension) : this(dimension, new V[dimension.Area]) { }
        protected Abstract(Geometry2D.Integer.Size dimension, V[] elements)
        {
            this.Dimensions = dimension;
            int minimum = Kean.Math.Integer.Minimum(elements.Length, dimension.Area);
            this.elements = new V[dimension.Area];
            Array.Copy(elements, 0, this.elements, 0, minimum);
        }
        #endregion
        public V this[int x, int y]
        {
            get { return this.elements[this.Index(x, y)]; }
            set { this.elements[this.Index(x, y)] = value; }
        }
        int Index(int x, int y)
        {
            return x * this.Dimensions.Height + y; // Column major order 
            // Use y * this.Dimensions.Width + x for row major order
        }
        public MatrixType Copy()
        {
            MatrixType result = new MatrixType() { Dimensions = this.Dimensions, elements = new V[this.elements.Length] };
            Array.Copy(this.elements, result.elements, this.elements.Length);
            return result;
        }
        #region Arithmetic Matrix - Matrix Operators
        public static MatrixType operator +(Abstract<MatrixType, R, V> left, MatrixType right)
        {
            if (left.Dimensions != right.Dimensions)
                new Exception.InvalidDimensions();
            MatrixType result = new MatrixType() 
            { 
                Dimensions = left.Dimensions, 
                elements = new V[left.Dimensions.Area] 
            };
            for (int i = 0; i < result.elements.Length; i++)
                result.elements[i] = (R)left.elements[i] + right.elements[i];
            return result;
        }
        public static MatrixType operator *(Abstract<MatrixType, R, V> left, MatrixType right)
        {
            if (left.Dimensions.Width != right.Dimensions.Height)
                new Exception.InvalidDimensions();
            MatrixType result = new MatrixType() 
            { 
                Dimensions = new Geometry2D.Integer.Size(right.Dimensions.Width, left.Dimensions.Height) ,
                elements = new V[right.Dimensions.Width * left.Dimensions.Height]
            };
            for (int x = 0; x < right.Dimensions.Width; x++)
                for (int y = 0; y < left.Dimensions.Height; y++)
                    for (int z = 0; z < left.Dimensions.Width; z++)
                        result[x, y] = (R)result[x, y] + (R)left[z, y] * right[x, z];
            return result;
        }
        public static MatrixType operator -(Abstract<MatrixType, R, V> left, MatrixType right)
        {
            return left + (-right);
        }
        #endregion
        #region Static Operators
        public static MatrixType operator +(V left, Abstract<MatrixType, R, V> right)
        {
            MatrixType result = new MatrixType() 
            { 
                Dimensions = right.Dimensions,
                elements = new V[right.Dimensions.Area]
            };
            for (int i = 0; i < result.elements.Length; i++)
                result.elements[i] = (R)left + right.elements[i];
            return result;
        }
        public static MatrixType operator +(Abstract<MatrixType, R, V> left, V right)
        {
            return right * left;
        }
        public static MatrixType operator *(V left, Abstract<MatrixType, R, V> right)
        {
            MatrixType result = new MatrixType()
            {
                Dimensions = right.Dimensions,
                elements = new V[right.Dimensions.Area]
            };
            for (int i = 0; i < result.elements.Length; i++)
                result.elements[i] = (R)left * right.elements[i];
            return result;
        }
        public static MatrixType operator *(Abstract<MatrixType, R, V> left, V right)
        {
            return right * left;
        }
        public static MatrixType operator /(Abstract<MatrixType, R, V> left, V right)
        {
            return (new R().One / right) * left;
        }
        public static MatrixType operator -(Abstract<MatrixType, R, V> value)
        {
            return new R().One.Negate() * value;
        }
        public static bool operator ==(Abstract<MatrixType, R, V> left, Abstract<MatrixType, R, V> right)
        {
            return
                object.ReferenceEquals(left, right) || (!object.ReferenceEquals(left, null) && !object.ReferenceEquals(right, null)) &&
                left.Equals(right);
        }
        public static bool operator !=(Abstract<MatrixType, R, V> left, Abstract<MatrixType, R, V> right)
        {
            return !(left == right);
        }
        #endregion
        #region Static Methods
        public static MatrixType Identity(int order)
        {
            MatrixType result = new MatrixType()
            {
                Dimensions = new Kean.Math.Geometry2D.Integer.Size(order, order),
                elements = new V[order * order]
            };
            for (int i = 0; i < order; i++)
                result[i, i] = new R().One;
            return result;
        }
        #endregion
        #region Matrix Operations
        public MatrixType Transpose()
        {
            MatrixType result = new MatrixType()
            {
                Dimensions = new Kean.Math.Geometry2D.Integer.Size(this.Dimensions.Height, this.Dimensions.Width),
                elements = new V[this.Dimensions.Area]
            };
            for (int x = 0; x < result.Dimensions.Width; x++)
                for (int y = 0; y < result.Dimensions.Height; y++)
                    result[x, y] = this[y, x];
            return result;
        }
        #endregion
        #region Object overides and IEquatable<MatrixType>
        public override bool Equals(object other)
        {
            return (other is MatrixType) && this.Equals(other as MatrixType);
        }
        // other is not null here.
        public bool Equals(MatrixType other)
        {
            bool result = this.Dimensions == other.Dimensions;
            if (result)
            {
                for (int x = 0; x < this.Dimensions.Width; x++)
                    for (int y = 0; y < this.Dimensions.Height; y++)
                        result &= (R)this[x, y] == other[x, y];
            }
            return result;
        }
        public override int GetHashCode()
        {
            int result = this.Dimensions.GetHashCode();
            for (int i = 0; i < this.Dimensions.Area; i++)
                result ^= this.elements[i].GetHashCode();
            return result;
        }
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            for (int y = 0; y < this.Dimensions.Height; y++)
                for (int x = 0; x < this.Dimensions.Width - 1; x++)
                {
                    builder.Append(this[x, y].ToString());
                    builder.Append((x == this.Dimensions.Width - 1) ? "; " : ", ");
                }
            return builder.ToString();
        }
        #endregion
        #region Casts
        public static implicit operator Abstract<MatrixType, R, V>(V[] value)
        {
            MatrixType result = new MatrixType()
            {
                Dimensions = new Kean.Math.Geometry2D.Integer.Size(1, value.Length),
                elements = new V[value.Length]
            };
            Array.Copy(value, result.elements, value.Length);
            return result;
        }
        public static implicit operator V[](Abstract<MatrixType, R, V> value)
        {
            V[] result = new V[value.elements.Length];
            Array.Copy(value.elements, result, result.Length);
            return result;
        }
        #endregion
    }
}
