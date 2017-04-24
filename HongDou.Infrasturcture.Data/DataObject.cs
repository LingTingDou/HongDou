using System;
using System.Collections.Generic;

namespace HongDou.Infrasturcture.Data
{
    public partial class DataObject<T> : IEquatable<DataObject<T>>
    {
        public T ID { get; set; }

        public virtual bool Equals(DataObject<T> other)
        {
            if (object.ReferenceEquals(other, null))
                return false;

            return EqualityComparer<T>.Default.Equals(this.ID, other.ID);
        }

        public sealed override bool Equals(object obj)
        {
            return this.Equals(obj as DataObject<T>);
        }

        public override int GetHashCode()
        {
            if (default(T) == null && this.ID == null)
                return base.GetHashCode();

            return this.ID.GetHashCode();
        }

        public static bool operator ==(DataObject<T> x, DataObject<T> y)
        {
            if (object.ReferenceEquals(x, y))
                return true;

            if (object.ReferenceEquals(x, null) || object.ReferenceEquals(y, null))
                return false;

            return x.Equals(y);
        }


        public static bool operator !=(DataObject<T> x, DataObject<T> y)
        {
            return !(x == y);
        }
    }
}