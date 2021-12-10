namespace VectorApp
{
    public class Vector3
    {
        private readonly double _x;
        private readonly double _y;
        private readonly double _z;

        public Vector3(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
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
                lhs._x + rhs._x,
                lhs._y + rhs._y,
                lhs._z + rhs._z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs._x - rhs._x,
                lhs._y - rhs._y,
                lhs._z - rhs._z);
        }

        public static double operator *(Vector3 lhs, Vector3 rhs)
        {
            return (lhs._x * rhs._x)
                + (lhs._y * rhs._y)
                + (lhs._z * rhs._z);
        }

        public static Vector3 operator &(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                (lhs._y * rhs._z) - (lhs._z * rhs._y),
                (lhs._z * rhs._x) - (lhs._x * rhs._z),
                (lhs._x * rhs._y) - (lhs._y * rhs._x));
        }

        public static Vector3 operator *(Vector3 vector, double scalar)
        {
            return new Vector3(
                vector._x * scalar,
                vector._y * scalar,
                vector._z * scalar);

        }

        public double Length()
        {
            return System.Math.Sqrt(this * this);
        }

        public override string ToString()
        {
            return $"({_x};{_y};{_z})";
        }
    }
}
