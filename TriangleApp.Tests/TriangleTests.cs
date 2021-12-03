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
        public void TriangleConstructor_OneOrMoreNegativeValuesOrZeros_ThrowArgumentException(double side1, double side2, double side3) =>
            Assert.Throws<ArgumentException>(() => new Triangle(side1, side2, side3));

        [TestCase(11.45, 12.23, 13.87)]
        [TestCase(75.87, 55.92, 45.37)]
        [TestCase(98.55, 81.27, 76.74)]
        [TestCase(5467458.7567, 8456734.3467, 8675654.0245)]
        [TestCase(11.47, 12.83, 13.37)]
        public void TriangleConstructor_ValidArguments(double side1, double side2, double side3) =>
            Assert.DoesNotThrow(() => new Triangle(side1, side2, side3));

        [TestCase(1, 2, 3)]
        [TestCase(87, 13, 65)]
        [TestCase(2, 3, 5)]
        [TestCase(34, 56, 91)]
        [TestCase(9648854, 18082311, 8433456)]
        [TestCase(78, 34, 43)]
        [TestCase(5838, 8401, 1674)]
        [TestCase(5396, 2995, 10)]
        [TestCase(40690, 2350, 52057)]
        [TestCase(72600, 97575, 17430)]
        [TestCase(926237, 310559, 155257)]
        [TestCase(4950146, 2677910, 9962076)]
        [TestCase(3308188, 1798112, 8624844)]
        [TestCase(360106, 887469, 4320323)]
        [TestCase(1541360, 6511637, 8364328)]
        [TestCase(911133394, 459796470, 380482844)]
        [TestCase(164230053113, 611286514585, 377069206469)]
        [TestCase(19931211046745180, 80635710712353193, 27830420580449572)]
        [TestCase(1E-9, 2E-10, 3E-11)]
        [TestCase(15E-136, 14E-136, 3E-135)]
        public void IsTriangle_ReturnFalse(double side1, double side2, double side3) =>
            Assert.IsFalse(new Triangle(side1, side2, side3).IsTriangle());

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

        // TODO: GetPerimeter() and GetArea() tests, including tests for double.NaN
    }
}