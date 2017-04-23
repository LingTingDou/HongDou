using HongDou.Infrasturcture.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HongDou.Infrastructure.Data.Test
{
    [TestClass]
    public class TestDataObject
    {
        [TestMethod]
        [TestCategory("DataObject相等性")]
        public void ReferenceEquals()
        {
            var obj1 = new DataObject<int>();
            var obj2 = obj1;

            AssertEquals(obj1, obj2);
        }

        [TestMethod]
        [TestCategory("DataObject相等性")]
        public void IdEquals()
        {
            var obj1 = new DataObject<int>();
            var obj2 = new DataObject<int>();

            obj1.ID = obj2.ID = 3;

            AssertEquals(obj1, obj2);
        }

        private void AssertEquals<T>(DataObject<T> x, DataObject<T> y)
        {
            Assert.IsTrue(Equals(x, y));
            Assert.IsTrue(x == y);
            Assert.IsTrue(x.Equals(y));
            Assert.IsTrue(y.Equals(x));
        }
    }
}
