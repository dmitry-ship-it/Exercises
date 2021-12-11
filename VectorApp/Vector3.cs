namespace VectorApp
{
    public class Vector3
    {
        public double X { get; init; }
        public double Y { get; init; }
        public double Z { get; init; }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 Add(Vector3 lhs, Vector3 rhs)
        {
            return lhs + rhs;
        }

        public static Vector3 Substruct(Vector3 lhs, Vector3 rhs)
        {
            return lhs - rhs;
        }

        public static double DotProduct(Vector3 lhs, Vector3 rhs)
        {
            return lhs * rhs;
        }

        public static Vector3 CrossProduct(Vector3 lhs, Vector3 rhs)
        {
            return lhs & rhs;
        }

        public static Vector3 Scale(Vector3 vector, double scalar)
        {
            return vector * scalar;
        }

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.X + rhs.X,
                lhs.Y + rhs.Y,
                lhs.Z + rhs.Z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.X - rhs.X,
                lhs.Y - rhs.Y,
                lhs.Z - rhs.Z);
        }

        public static double operator *(Vector3 lhs, Vector3 rhs)
        {
            return (lhs.X * rhs.X)
                + (lhs.Y * rhs.Y)
                + (lhs.Z * rhs.Z);
        }

        public static Vector3 operator &(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs.Y * rhs.Z) - (lhs.Z * rhs.Y),
                (lhs.Z * rhs.X) - (lhs.X * rhs.Z),
                (lhs.X * rhs.Y) - (lhs.Y * rhs.X));
        }

        public static Vector3 operator *(Vector3 vector, double scalar)
        {
            return new Vector3(
                vector.X * scalar,
                vector.Y * scalar,
                vector.Z * scalar);

        }

        public double Length()
        {
            return System.Math.Sqrt(this * this);
        }

        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }
    }
}
