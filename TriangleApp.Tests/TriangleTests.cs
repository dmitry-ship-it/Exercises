using NUnit.Framework;
using System;

namespace TriangleApp.Tests
{
    public class TriangleAppTests
    {
        [TestCase(11.45, 12.23, -13.87)]
        [TestCase(0.0, 12.12, 13.34)]
        [TestCase(-75, -55, 45)]
        [TestCase(-98, -81, -76)]
        [TestCase(5467458.7567, -8456734.3467, 8675654.0245)]
        [TestCase(11, 12, -13)]
        [TestCase(0, 12, 13)]
        [TestCase(11, 0, 13)]
        [TestCase(11, 12, 0)]
        [TestCase(0, 0, 0)]
        [TestCase(int.MinValue, int.MaxValue, int.MaxValue)]
        [TestCase(int.MinValue, int.MinValue, int.MinValue)]
        public void TriangleConstructor_OneOrMoreNegativeValuesOrZeros_ThrowArgumentException(double side1, double side2, double side3) =>
            Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));

        [TestCase(11.45, 12.23, 13.87)]
        [TestCase(75.87, 55.92, 45.37)]
        [TestCase(98.55, 81.27, 76.74)]
        [TestCase(5467458.7567, 8456734.3467, 8675654.0245)]
        [TestCase(11.47, 12.83, 13.37)]
        public void TriangleConstructor_ValidArguments(double side1, double side2, double side3) =>
            Assert.DoesNotThrow(() => new Triangle(side1, side2, side3));

        [TestCase(2, 3, 4)]
        [TestCase(9, 4, 7)]
        [TestCase(34, 58, 81)]
        [TestCase(41, 52, 65)]
        [TestCase(641, 652, 418)]
        [TestCase(646, 884, 827)]
        [TestCase(3372, 2058, 3096)]
        [TestCase(4888, 9202, 8411)]
        [TestCase(70001, 143686, 73686)]
        [TestCase(979095, 965108, 969067)]
        [TestCase(860403, 897988, 425483)]
        [TestCase(7623274, 13965102.999999, 6341829)]
        [TestCase(69319207, 60798144, 51546951)]
        [TestCase(192417869.9999999, 97513107, 94904763)]
        [TestCase(2E-5, 3E-5, 4E-5)]
        [TestCase(95E-88, 80E-88, 51E-88)]
        [TestCase(20E-132, 18E-132, 18E-132)]
        [TestCase(55E-200, 60E-200, 44E-200)]
        [TestCase(79E-307, 40E-307, 86E-307)]
        public void IsTriangle_ReturnTrue(double side1, double side2, double side3) =>
            Assert.IsTrue(new Triangle(side1, side2, side3).IsTriangle());

        [TestCase(2, 3, 4, 9, double.Epsilon)]
        [TestCase(9, 4, 7, 20, double.Epsilon)]
        [TestCase(34, 58, 81, 173, double.Epsilon)]
        [TestCase(41, 52, 65, 158, double.Epsilon)]
        [TestCase(641, 652, 418, 1711, double.Epsilon)]
        [TestCase(646, 884, 827, 2357, double.Epsilon)]
        [TestCase(3372, 2058, 3096, 8526, double.Epsilon)]
        [TestCase(4888, 9202, 8411, 22501, double.Epsilon)]
        [TestCase(70001, 143686, 73686, 287373, double.Epsilon)]
        [TestCase(979095, 965108, 969067, 2913270, double.Epsilon)]
        [TestCase(860403, 897988, 425483, 2183874, double.Epsilon)]
        [TestCase(7623274, 13965102.999999, 6341829, 27930205.999999, double.Epsilon)]
        [TestCase(69319207, 60798144, 51546951, 181664302, double.Epsilon)]
        [TestCase(192417869.9999999, 97513107, 94904763, 384835739.9999999, double.Epsilon)]
        [TestCase(2E-5, 3E-5, 4E-5, 9E-5, double.Epsilon)]
        [TestCase(95E-88, 80E-88, 51E-88, 226E-88, double.Epsilon)]
        [TestCase(20E-132, 18E-132, 18E-132, 56E-132, double.Epsilon)]
        [TestCase(55E-200, 59E-200, 43E-200, 157E-200, 1E-207)]
        [TestCase(79E-307, 40E-307, 86E-307, 205E-307, double.Epsilon)]
        public void GetPerimeter_WithValidSides(double side1, double side2, double side3, double expected, double tolerance)
        {
            var result = new Triangle(side1, side2, side3).GetPerimeter();
            Assert.AreEqual(expected, result, tolerance);
        }

        [TestCase(2, 3, 4, 2.9047375, 1E-7)]
        [TestCase(9, 4, 7, 13.4164078, 1E-7)]
        [TestCase(34, 58, 81, 843.7066655, 1E-7)]
        [TestCase(41, 52, 65, 1065.2492666, 1E-7)]
        [TestCase(641, 652, 418, 127818.8455331, 1E-7)]
        [TestCase(646, 884, 827, 254876.5698498, 1E-7)]
        [TestCase(3372, 2058, 3096, 3126340.2593535, 1E-7)]
        [TestCase(4888, 9202, 8411, 20405100.1337888, 1E-7)]
        [TestCase(70001, 143686, 73686, 19250170.2006540, 1E-7)]
        [TestCase(979095, 965108, 969067, 408292624398.54144, 1E-7)]
        [TestCase(860403, 897988, 425483, 180773613924.44724, 1E-7)]
        [TestCase(7623274, 13965102.999999, 6341829, 18392522.8020656, 1E-7)]
        [TestCase(69319207, 60798144, 51546951, 1518416260296388.2, 1E-7)]
        [TestCase(192417869.9999999, 97513107, 94904763, 230368586.3444493, 1E-7)]
        [TestCase(2E-5, 3E-5, 4E-5, 2.9047375E-10, 1E-17)]
        [TestCase(9E-81, 4E-81, 7E-81, 1.3336552E-161, 1E-168)]
        public void GetArea_WithValidSides(double side1, double side2, double side3, double expected, double tolerance)
        {
            var result = new Triangle(side1, side2, side3).GetArea();
            Assert.AreEqual(expected, result, tolerance);
        }

        private static readonly object[] InvalidSides =
        {
            new object[] {1, 2, 3},
            new object[] {2, 3, 5},
            new object[] {87, 13, 65},
            new object[] {34, 56, 91},
            new object[] {78, 34, 43},
            new object[] {5838, 8401, 1674},
            new object[] {5396, 2995, 10},
            new object[] {40690, 2350, 52057},
            new object[] {72600, 97575, 17430},
            new object[] {926237, 310559, 155257},
            new object[] {360106, 887469, 4320323},
            new object[] {9648854, 18082311, 8433456},
            new object[] {4950146, 2677910, 9962076},
            new object[] {3308188, 1798112, 8624844},
            new object[] {1541360, 6511637, 8364328},
            new object[] {911133394, 459796470, 380482844},
            new object[] {164230053113, 611286514585, 377069206469},
            new object[] {19931211046745180, 80635710712353193, 27830420580449572},
            new object[] {1E-9, 2E-10, 3E-11},
            new object[] {15E-136, 14E-136, 3E-135},
            new object[] {21E-301, 26E-301, 47E-301}
        };

        [TestCaseSource(nameof(InvalidSides))]
        public void IsTriangle_ReturnFalse(double side1, double side2, double side3) =>
            Assert.IsFalse(new Triangle(side1, side2, side3).IsTriangle());

        [TestCaseSource(nameof(InvalidSides))]
        public void GetPerimeter_WithInvalidSides(double side1, double side2, double side3)
        {
            var result = new Triangle(side1, side2, side3).GetPerimeter();
            Assert.IsNaN(result);
        }

        [TestCaseSource(nameof(InvalidSides))]
        public void GetArea_WithInvalidSides(double side1, double side2, double side3)
        {
            var result = new Triangle(side1, side2, side3).GetArea();
            Assert.IsNaN(result);
        }
    }
}
