namespace Mathy
{
    public struct Vector3
    {
        public float X;
        public float Y;
        public float Z;

        public Vector3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 Zero { get { return new Vector3(0f, 0f, 0f); } }
        public static Vector3 One { get { return new Vector3(1f, 1f, 1f); } }
        public static Vector3 Up { get { return new Vector3(0f, 1f, 0f); } }
        public static Vector3 Down { get { return new Vector3(0f, -1f, 0f); } }
        public static Vector3 Forward { get { return new Vector3(0f, 0f, 1f); } }
        public static Vector3 Backward { get { return new Vector3(0f, 0f, -1f); } }
        public static Vector3 Right { get { return new Vector3(1f, 0f, 0f); } }
        public static Vector3 Left { get { return new Vector3(-1f, 0f, 0f); } }

    }
}
