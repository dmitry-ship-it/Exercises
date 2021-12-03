using System;
using System.Collections.Generic;

namespace TriangleApp
{
    public class Triangle
    {
        private readonly List<double> _sides;

        public Triangle(double side1, double side2, double side3)
        {
            if (side1 < double.Epsilon || side2 < double.Epsilon || side3 < double.Epsilon)
            {
                throw new ArgumentException("One or more sides are negative or zero.");
            }

            _sides = new List<double> { side1, side2, side3 };
        }

        public bool IsTriangle()
        {
            return _sides[0] + _sides[1] > _sides[2]
                && _sides[0] + _sides[2] > _sides[1]
                && _sides[1] + _sides[2] > _sides[0];
        }

        public double GetPerimeter()
        {
            return IsTriangle() ? _sides[0] + _sides[1] + _sides[2] : double.NaN;
        }

        public double GetArea()
        {
            if (!IsTriangle())
            {
                return double.NaN;
            }

            var halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter
                * (halfPerimeter - _sides[0])
                * (halfPerimeter - _sides[1])
                * (halfPerimeter - _sides[2]));
        }
    }
}
