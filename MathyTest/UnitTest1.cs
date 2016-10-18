using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathy;

namespace MathyTest
{
    [TestClass]
    public class Vector3Test
    {
        [TestMethod]
        public void TestConstructors()
        {
            // Default constructor
            var testVector = new Vector3();

            Assert.AreEqual(0f, testVector.X);
            Assert.AreEqual(0f, testVector.Y);
            Assert.AreEqual(0f, testVector.Z);

            // float float float constructor
            const float constX = -6f;
            const float constY = 2.49f;
            const float constZ = 49f;

            testVector = new Vector3(-6f, 2.49f, 49f);

            Assert.AreEqual(constX, testVector.X);
            Assert.AreEqual(constY, testVector.Y);
            Assert.AreEqual(constZ, testVector.Z);
        }

        [TestMethod]
        public void TestEquality()
        {
            Vector3 one = Vector3.One;
            Vector3 createdOne = new Vector3(1f, 1f, 1f);
            Assert.AreEqual(one, createdOne);

            int hash = one.GetHashCode();
            int createdHash = createdOne.GetHashCode();
            Assert.AreEqual(hash, createdHash);

            // bool onesAreEqual = Vector3.One == createdOne;
        }
    }
}
