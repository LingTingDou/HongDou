using System;
using System.Collections.Generic;

namespace HongDou.Infrasturcture.Data
{
    public abstract partial class BaseDataObject<T> : IEquatable<BaseDataObject<T>>
    {
        public T ID { get; set; }

        public virtual bool Equals(BaseDataObject<T> other)
        {
            if (ReferenceEquals(other, null))
                return false;

            return EqualityComparer<T>.Default.Equals(this.ID, other.ID);
        }

        public sealed override bool Equals(object obj)
        {
            return this.Equals(obj as BaseDataObject<T>);
        }

        public override int GetHashCode()
        {
            if (default(T) == null && this.ID == null)
                return base.GetHashCode();

            return this.ID.GetHashCode();
        }

        public static bool operator ==(BaseDataObject<T> x, BaseDataObject<T> y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (ReferenceEquals(x, null) || ReferenceEquals(y, null))
                return false;

            return x.Equals(y);
        }


        public static bool operator !=(BaseDataObject<T> x, BaseDataObject<T> y)
        {
            return !(x == y);
        }
    }
}