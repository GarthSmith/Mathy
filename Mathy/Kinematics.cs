using System;

namespace Mathy
{
    public static class Kinematics
    {
        public static float GetDistance(float initVelo, float acc, float seconds)
        {
            return initVelo * seconds + 0.5f * acc * seconds * seconds;
        }

        public static float GetFinalVelocity(float initVelo, float acc, float distance)
        {
            return (float)Math.Sqrt(initVelo * initVelo + 2 * acc * distance);
        }

        public static Kine3 GetFinalVelo(Kine3 k)
        {
            // TODO: Does this make new float? or reuse existing instance of float?
            // is float? value type or reference type
            Kine3 withAnswers = k;

            if (!withAnswers.FinalXvelo.HasValue)
            {
                if (withAnswers.InitXvelo.HasValue && k.Xacc.HasValue && k.Xdistance.HasValue)
                    withAnswers.FinalXvelo = GetFinalVelocity(k.InitXvelo.Value, k.Xacc.Value, k.Xdistance.Value);
            }
            if (!k.FinalYvelo.HasValue)
            {
                if (k.InitYvelo.HasValue && k.Yacc.HasValue && k.Ydistance.HasValue)
                    withAnswers.FinalYvelo = GetFinalVelocity(k.InitYvelo.Value, k.Yacc.Value, k.Ydistance.Value);
            }
            if (!k.FinalZvelo.HasValue)
            {
                if (k.InitZvelo.HasValue && k.Zacc.HasValue && k.Zdistance.HasValue)
                    withAnswers.FinalZvelo = GetFinalVelocity(k.InitZvelo.Value, k.Zacc.Value, k.Zdistance.Value);
            }
            return withAnswers;
        }
    }
}
