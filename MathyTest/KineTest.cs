using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mathy;

namespace MathyTest
{
    [TestClass]
    public class KineTest
    {
        [TestMethod]
        public void KineTestMethod()
        {
            Kine3 toTest = new Kine3();
            toTest.InitXvelo = 0f;
            toTest.Xacc = 0f;
            toTest.Xdistance = 0f;
            toTest = Kinematics.GetFinalVelo(toTest);
            Assert.AreEqual(true, toTest.FinalXvelo.HasValue);
            Assert.AreEqual(0f, toTest.FinalXvelo);

            toTest.InitXvelo = 1f;
            toTest.FinalXvelo = null;

            toTest = Kinematics.GetFinalVelo(toTest);
            Assert.AreEqual(true, toTest.FinalXvelo.HasValue);
            Assert.AreEqual(1f, toTest.FinalXvelo);
        }
    }
}
