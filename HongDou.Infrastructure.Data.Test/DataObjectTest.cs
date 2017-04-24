using System;
using System.Collections.Generic;
using HongDou.Infrasturcture.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongDou.Infrastructure.Data.Test
{
    [TestClass]
    public class DataObjectTest
    {
        [TestMethod]
        [TestCategory("DataObject.Equality")]
        public void Equality()
        {
            // int
            ReferenceEquals<int>();
            NullReferenceNotEquals<int>();

            IDEquals(default(int));
            IDEquals(9999);

            IDNotEquals(default(int), 9999);
            IDNotEquals(3, 1353);

            // guid
            ReferenceEquals<Guid>();
            NullReferenceNotEquals<Guid>();

            IDEquals(default(Guid));
            IDEquals(Guid.NewGuid());

            IDNotEquals(Guid.NewGuid(), Guid.NewGuid());

            // string
            ReferenceEquals<string>();
            NullReferenceNotEquals<string>();

            IDEquals(default(string));
            IDEquals("Identifier");

            IDNotEquals("ID1", "ID2");
        }

        private void ReferenceEquals<T>()
        {
            DataObject<T> x;
            DataObject<T> y;

            x = y = new DataObject<T>();

            this.AssertEqual(x, y);
        }

        private void IDEquals<T>(T id)
        {
            var x = new DataObject<T>() { ID = id };
            var y = new DataObject<T>() { ID = id };

            this.AssertEqual(x, y);
        }

        private void IDNotEquals<T>(T id1, T id2)
        {
            var x = new DataObject<T>() { ID = id1 };
            var y = new DataObject<T>() { ID = id2 };

            this.AssertNotEqual(x, y);
        }

        private void NullReferenceNotEquals<T>()
        {
            var x = new DataObject<T>();
            DataObject<T> y = null;

            this.AssertNotEqual(x, y);
        }

        private void AssertEqual<T>(DataObject<T> x, DataObject<T> y)
        {
            Assert.AreEqual(x, y);
            Assert.AreEqual(y, x);

            Assert.IsTrue(object.Equals(x, y));
            Assert.IsTrue(object.Equals(y, x));

            Assert.IsTrue(x == y);
            Assert.IsTrue(y == x);

            Assert.IsTrue(EqualityComparer<DataObject<T>>.Default.Equals(x, y));
            Assert.IsTrue(EqualityComparer<DataObject<T>>.Default.Equals(y, x));

            Assert.IsFalse(x != y);
            Assert.IsFalse(y != x);

            if (x != null)
                Assert.IsTrue(x.Equals(y));

            if (y != null)
                Assert.IsTrue(y.Equals(x));
        }

        private void AssertNotEqual<T>(DataObject<T> x, DataObject<T> y)
        {
            Assert.AreNotEqual(x, y);
            Assert.AreNotEqual(y, x);

            Assert.IsFalse(object.Equals(x, y));
            Assert.IsFalse(object.Equals(y, x));

            Assert.IsFalse(x == y);
            Assert.IsFalse(y == x);

            Assert.IsFalse(EqualityComparer<DataObject<T>>.Default.Equals(x, y));
            Assert.IsFalse(EqualityComparer<DataObject<T>>.Default.Equals(y, x));

            Assert.IsTrue(x != y);
            Assert.IsTrue(y != x);

            if (x != null)
                Assert.IsFalse(x.Equals(y));

            if (y != null)
                Assert.IsFalse(y.Equals(x));
        }
    }
}
