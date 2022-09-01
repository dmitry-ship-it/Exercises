using NUnit.Framework;
using System;

namespace BinaryTreeTask.Tests
{
    public class TestResultTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Ctor_NullOrEmptyStudentName_ThrowsArgumentNullException(string studentName)
            => Assert.Throws<ArgumentNullException>(() => new TestResult(studentName, "Math", new DateTime(2020, 5, 15), 7));

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void Ctor_NullOrEmptyTestName_ThrowsArgumentNullException(string testName)
            => Assert.Throws<ArgumentNullException>(() => new TestResult("Vasya Pupkin", testName, new DateTime(2021, 11, 3), 5));

        [TestCase("05/27/3011")]
        [TestCase("09/18/2080")]
        [TestCase("11/06/2046")]
        public void Ctor_FutureDate_ThrowsArgumentOutOfRangeException(DateTime date)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new TestResult("Vasya Pupkin", "Math", date, 5));

        [TestCase(int.MinValue)]
        [TestCase(-13)]
        [TestCase(-2)]
        [TestCase(-1)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(36)]
        [TestCase(int.MaxValue)]
        public void Ctor_MarkNegativeOrMoreThanTen_ThrowsArgumentOutOfRangeException(int mark)
            => Assert.Throws<ArgumentOutOfRangeException>(() => new TestResult("Vasya Pupkin", "Math", new DateTime(2019, 6, 22), mark));

        [TestCase("Tracy Sierra", "Computer graphics", "12/28/2021", 1)]
        [TestCase("Leja Salter", "Relational databases", "12/27/2021", 10)]
        [TestCase("Ammaarah Mcneil", "Distributed computing", "11/25/2021", 0)]
        [TestCase("Kaylem Marin", "Object-oriented programming", "01/01/2010", 5)]
        public void Ctor_ConstructsFine(string studentName, string testName, DateTime date, int mark)
            => Assert.DoesNotThrow(() => new TestResult(studentName, testName, date, mark));
    }
}