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

        [TestMethod] public void CheckOneDimensionalSolve()
        {
            Kine1 test = new Kine1();
            test.InitialVelocity = 0f;
            test.FinalVelocity = 300f;
            test.Time = 4;
            test = KinematicsOneDimensional.Solve(test);

            Assert.IsTrue(test.Distance.HasValue);
            Assert.IsTrue(test.Acceleration.HasValue);
            System.Diagnostics.Debug.WriteLine("Got a distance of " + test.Distance + " and acceleration " + test.Acceleration);

            test.InitialVelocity = 0f;
            test.FinalVelocity = null;
            test.Time = 100f;
            test.Acceleration = 1f;
            test.Distance = null;
            test = KinematicsOneDimensional.Solve(test);
            float calculatedFinal = test.FinalVelocity.Value;
            const float expectedFinal = 100f;
            float difference = expectedFinal - calculatedFinal;
            Assert.IsTrue(difference < 0.00001f);
            Assert.IsTrue(difference < float.Epsilon);
            System.Diagnostics.Debug.WriteLine("Got a final velocity of " + test.FinalVelocity.Value);

            test.InitialVelocity = 30;
            test.FinalVelocity = 0;
            test.Acceleration = -8;
            test.Distance = null;
            test.Time = null;
            test = KinematicsOneDimensional.Solve(test);
            difference = System.Math.Abs(test.Distance.Value - 56.3f);
            Assert.IsTrue(difference < 0.1f);
            System.Diagnostics.Debug.WriteLine("Actual was " + test.Distance.Value);
        }
    }
}
