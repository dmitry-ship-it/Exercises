using System;

#pragma warning disable S1210

namespace BinaryTreeTask
{
    public class TestResult : IComparable<TestResult>
    {
        public string StudentName { get; init; }
        public string TestName { get; init; }
        public DateTime Date { get; init; }
        public int Mark { get; init; }

        public TestResult(string studentName, string testName, DateTime date, int mark)
        {
            if (string.IsNullOrWhiteSpace(studentName))
            {
                throw new ArgumentNullException(nameof(studentName));
            }

            if (string.IsNullOrWhiteSpace(testName))
            {
                throw new ArgumentNullException(nameof(testName));
            }

            if (date > DateTime.Now)
            {
                throw new ArgumentOutOfRangeException(nameof(date), "Invalid date.");
            }

            if (mark < 0 || mark > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(mark), "Mark cannot be negative or more than 10.");
            }

            StudentName = studentName;
            TestName = testName;
            Date = date;
            Mark = mark;
        }

        public int CompareTo(TestResult other)
        {
            return Mark.CompareTo(other.Mark);
        }
    }
}
