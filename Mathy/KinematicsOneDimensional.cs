using System;

namespace Mathy
{
    public static class KinematicsOneDimensional
    {
        public static Kine1 Solve(Kine1 incomplete)
        {
            // Need at least three variables to solve for the other two.
            int variableCount = CountGivens(incomplete);
            if (variableCount < 3)
                throw new Exception("Not enough data to solve");

            // At this point, for whatever variable, or two variables,
            // are missing, we should be able to solve for them using
            // the rest of the info.

            if (!incomplete.Distance.HasValue)
                incomplete = GetDistance(incomplete);

            if (!incomplete.Acceleration.HasValue)
                incomplete = GetAcceleration(incomplete);

            if (!incomplete.Time.HasValue)
                incomplete = GetTime(incomplete);

            if (!incomplete.FinalVelocity.HasValue)
                incomplete = GetFinalVelocity(incomplete);

            if (!incomplete.InitialVelocity.HasValue)
                incomplete = GetInitialVelocity(incomplete);

            return incomplete;
        }

        private static int CountGivens(Kine1 k)
        {
            int count = 0;
            if (k.Acceleration.HasValue)
                count++;
            if (k.Distance.HasValue)
                count++;
            if (k.FinalVelocity.HasValue)
                count++;
            if (k.InitialVelocity.HasValue)
                count++;
            if (k.Time.HasValue)
                count++;
            return count;
        }

        private static Kine1 GetTime(Kine1 k)
        {
            Kine1 solved = k;
            if (k.InitialVelocity.HasValue && k.FinalVelocity.HasValue && k.Acceleration.HasValue)
            {
                solved.Time = (k.FinalVelocity - k.InitialVelocity) / k.Acceleration;
                return solved;
            }
            if (k.InitialVelocity.HasValue && k.FinalVelocity.HasValue && k.Distance.HasValue)
            {
                solved.Time = 2f * k.Distance / (k.InitialVelocity + k.FinalVelocity);
                return solved;
            }
            if (k.Distance.HasValue && k.InitialVelocity.HasValue && k.Acceleration.HasValue)
            {
                throw new NotImplementedException("Need a better way to handle two possible solutions");
            }
            throw new ArgumentException("Not enough data to solve for time.");
        }

        private static Kine1 GetInitialVelocity(Kine1 k)
        {
            Kine1 solved = k;
            if (k.Acceleration.HasValue && k.Distance.HasValue && k.Time.HasValue)
            {
                solved.InitialVelocity = (k.Distance - 0.5f * k.Acceleration * k.Time * k.Time) / k.Time;
                return solved;
            }

            if (k.Distance.HasValue && k.FinalVelocity.HasValue && k.Time.HasValue)
            {
                solved.InitialVelocity = k.Distance * 2f / k.Time - k.FinalVelocity;
                return solved;
            }

            if (k.Distance.HasValue && k.FinalVelocity.HasValue && k.Acceleration.HasValue)
            {
                throw new NotImplementedException("Need a better way to handle multiple solutions.");
            }

            throw new ArgumentException("Not enough data provided to solve for initial velocity.");
        }

        private static Kine1 GetFinalVelocity(Kine1 k)
        {
            Kine1 solved = k;
            if (k.InitialVelocity.HasValue && k.Time.HasValue && k.Acceleration.HasValue)
            {
                solved.FinalVelocity = k.InitialVelocity + k.Acceleration * k.Time;
                return solved;
            }
            if (k.InitialVelocity.HasValue && k.Distance.HasValue && k.Time.HasValue)
            {
                solved.FinalVelocity = k.Distance * 2f / k.Time - k.InitialVelocity;
                return solved;
            }
            if (k.InitialVelocity.HasValue && k.Acceleration.HasValue && k.Distance.HasValue)
            {
                throw new NotImplementedException("Need a better way to handle multiple solutions.");
            }
            throw new ArgumentException("Not enough data to solve for final velocity.");
        }

        private static Kine1 GetDistance(Kine1 k)
        {
            Kine1 solved = k;
            if (k.InitialVelocity.HasValue && k.Acceleration.HasValue && k.Time.HasValue)
            {
                solved.Distance = k.InitialVelocity.Value * k.Time + 0.5f * k.Acceleration * k.Time * k.Time;
                return solved;
            }

            if (k.InitialVelocity.HasValue && k.Acceleration.HasValue && k.FinalVelocity.HasValue)
            {
                solved.Distance = (k.FinalVelocity * k.FinalVelocity - k.InitialVelocity * k.InitialVelocity) / (2f * k.Acceleration);
                return solved;
            }

            if (k.InitialVelocity.HasValue && k.FinalVelocity.HasValue && k.Time.HasValue)
            {
                solved.Distance = (k.InitialVelocity + k.FinalVelocity) / 2f * k.Time;
                return solved;
            }

            throw new Exception("Not enough data to solve for distance.");
        }

        private static Kine1 GetAcceleration(Kine1 k)
        {
            Kine1 solved = k;
            if (k.Distance.HasValue && k.InitialVelocity.HasValue && k.Time.HasValue)
            {
                solved.Acceleration = (k.Distance - k.InitialVelocity * k.Time) * 2f / k.Time / k.Time;
                return solved;
            }

            if (k.Distance.HasValue && k.InitialVelocity.HasValue && k.FinalVelocity.HasValue)
            {
                solved.Acceleration = (k.FinalVelocity * k.FinalVelocity - k.InitialVelocity * k.InitialVelocity) / 2f / k.Distance;
                return solved;
            }

            if (k.Time.HasValue && k.InitialVelocity.HasValue && k.FinalVelocity.HasValue)
            {
                solved.Acceleration = (k.FinalVelocity - k.InitialVelocity) / k.Time;
                return solved;
            }

            throw new Exception("Not enough data to solve for acceleration");
        }
    }
}
