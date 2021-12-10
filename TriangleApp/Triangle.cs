using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            return IsTriangle() ? _sides.Sum() : double.NaN;
        }

        public double GetArea()
        {
            if (!IsTriangle())
            {
                return double.NaN;
            }

            var halfPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(halfPerimeter * _sides.Select(side => halfPerimeter - side)
                    .Aggregate((currentSide, nextSide) => currentSide * nextSide));
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append("Sides:");
            result.Append(Environment.NewLine);

            result.Append("a = ");
            result.Append(_sides[0]);
            result.Append(Environment.NewLine);
            result.Append("b = ");
            result.Append(_sides[1]);
            result.Append(Environment.NewLine);
            result.Append("c = ");
            result.Append(_sides[2]);
            result.Append(Environment.NewLine);

            if (IsTriangle())
            {
                result.Append("Perimeter = ");
                result.Append(GetPerimeter());
                result.Append(Environment.NewLine);

                result.Append("Area = ");
                result.Append(GetArea());
                result.Append(Environment.NewLine);
            }
            else
            {
                result.Append("This triangle does not exist.");
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}