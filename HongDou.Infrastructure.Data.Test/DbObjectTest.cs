using System.Collections.Generic;
using HongDou.Infrasturcture.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongDou.Infrastructure.Data.Test
{
    [TestClass]
    public class DBObjectTest
    {
        [TestMethod]
        [TestCategory("DBObject.Equality")]
        public void Equality()
        {
            ReferenceEquals();
            NullReferenceNotEquals();

            IDEquals(default(int));
            IDEquals(9999);

            IDNotEquals(default(int), 9999);
            IDNotEquals(3, 1353);
        }

        private void ReferenceEquals()
        {
            DBObject x;
            DBObject y;

            x = y = new DBObject();

            this.AssertEqual(x, y);
        }

        private void IDEquals(int id)
        {
            var x = new DBObject() { ID = id };
            var y = new DBObject() { ID = id };

            this.AssertEqual(x, y);
        }

        private void IDNotEquals(int id1, int id2)
        {
            var x = new DBObject() { ID = id1 };
            var y = new DBObject() { ID = id2 };

            this.AssertNotEqual(x, y);
        }

        private void NullReferenceNotEquals()
        {
            var x = new DBObject();
            DBObject y = null;

            this.AssertNotEqual(x, y);
        }

        private void AssertEqual(DBObject x, DBObject y)
        {
            Assert.AreEqual(x, y);
            Assert.AreEqual(y, x);

            Assert.IsTrue(object.Equals(x, y));
            Assert.IsTrue(object.Equals(y, x));

            Assert.IsTrue(x == y);
            Assert.IsTrue(y == x);

            Assert.IsTrue(EqualityComparer<DBObject>.Default.Equals(x, y));
            Assert.IsTrue(EqualityComparer<DBObject>.Default.Equals(y, x));

            Assert.IsFalse(x != y);
            Assert.IsFalse(y != x);

            if (x != null)
                Assert.IsTrue(x.Equals(y));

            if (y != null)
                Assert.IsTrue(y.Equals(x));
        }

        private void AssertNotEqual(DBObject x, DBObject y)
        {
            Assert.AreNotEqual(x, y);
            Assert.AreNotEqual(y, x);

            Assert.IsFalse(object.Equals(x, y));
            Assert.IsFalse(object.Equals(y, x));

            Assert.IsFalse(x == y);
            Assert.IsFalse(y == x);

            Assert.IsFalse(EqualityComparer<DBObject>.Default.Equals(x, y));
            Assert.IsFalse(EqualityComparer<DBObject>.Default.Equals(y, x));

            Assert.IsTrue(x != y);
            Assert.IsTrue(y != x);

            if (x != null)
                Assert.IsFalse(x.Equals(y));

            if (y != null)
                Assert.IsFalse(y.Equals(x));
        }

    }
}
