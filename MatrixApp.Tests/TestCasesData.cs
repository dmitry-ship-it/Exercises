using NUnit.Framework;
using System.Collections.Generic;

namespace MatrixApp.Tests
{
    internal static class TestCasesData
    {
        public static IEnumerable<TestCaseData> ValidArrays
        {
            get
            {
                yield return new TestCaseData(new double[,]
                {
                    { 1 }
                });
                yield return new TestCaseData(new double[,]
                {
                    { 78.77, 48.64 },
                    { 91.16, 27.48 }
                });
                yield return new TestCaseData(new double[,]
                {
                    { 94.83 },
                    { 24.43 },
                    { 89.20 }
                });
                yield return new TestCaseData(new double[,]
                {
                    { 50.46, 55.32, 42.45 }
                });
            }
        }

        public static IEnumerable<TestCaseData> ValidArrayPairsWithDimensionMismatch
        {
            get
            {
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 61.83, 78.64 }
                    },
                    new double[,]
                    {
                        { 56.88 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 61.83 },
                        { 88.04 }
                    },
                    new double[,]
                    {
                        { 56.88 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 61.83 }
                    },
                    new double[,]
                    {
                        { 56.88, 67.40 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 61.83 }
                    },
                    new double[,]
                    {
                        { 56.88 },
                        { 90.24 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 93.7, 67.32, 58.25 }
                    },
                    new double[,]
                    {
                        { 84.11 },
                        { 30.16 },
                        { 84.12 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 75.88 },
                        { 62.38 },
                        { 54.75 }
                    },
                    new double[,]
                    {
                        { 41.86, 40.08, 95.62 }
                    });
            }
        }

        public static IEnumerable<TestCaseData> ValidArrayPairsWithDimensionMismatchForMultiply
        {
            get
            {
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 61.83, 78.64 }
                    },
                    new double[,]
                    {
                        { 56.88 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 61.83 }
                    },
                    new double[,]
                    {
                        { 56.88 },
                        { 90.24 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 89.87, 70.63, 21.50 }
                    },
                    new double[,]
                    {
                        { 82.97 },
                        { 62.63 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 23.91, 48.52 }
                    },
                    new double[,]
                    {
                        { 61.72 },
                        { 46.03 },
                        { 61.40 }
                    });
            }
        }

        public static IEnumerable<TestCaseData> ValidArrayPairsWithSameSizeWithAddResult
        {
            get
            {
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 97.18 }
                    },
                    new double[,]
                    {
                        { 60.79 }
                    },
                    new double[,]
                    {
                        { 157.97 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 84.85, 26.98 },
                        { 41.42, 42.27 }
                    },
                    new double[,]
                    {
                        { 95.87, 46.52 },
                        { 74.38, 61.93 }
                    },
                    new double[,]
                    {
                        { 180.72, 73.50 },
                        { 115.80, 104.20 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 38.65, 80.91, 19.26 },
                        { 25.63, 27.39, 42.34 },
                        { 25.29, 75.16, 56.55 }
                    },
                    new double[,]
                    {
                        { 41.45, 80.78, 52.78 },
                        { 27.77, 38.00, 64.38 },
                        { 35.71, 73.96, 51.79 }
                    },
                    new double[,]
                    {
                        { 80.10, 161.69, 72.04 },
                        { 53.40, 65.39, 106.72 },
                        { 61.00, 149.12, 108.34 }
                    });
            }
        }

        public static IEnumerable<TestCaseData> ValidArrayPairsWithSameSizeWithSubtractResult
        {
            get
            {
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 68.85 }
                    },
                    new double[,]
                    {
                        { 10.12 }
                    },
                    new double[,]
                    {
                        { 58.73 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 87.04, 49.03 },
                        { 32.70, 82.65 }
                    },
                    new double[,]
                    {
                        { 37.95, 88.29 },
                        { 35.04, 16.95 }
                    },
                    new double[,]
                    {
                        { 49.09, -39.26 },
                        { -2.34, 65.70 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 25.07, 57.96, 83.68 },
                        { 14.79, 90.90, 61.14 },
                        { 37.26, 50.74, 79.26 }
                    },
                    new double[,]
                    {
                        { 22.64, 58.61, 34.07 },
                        { 19.51, 85.74, 37.12 },
                        { 67.84, 29.39, 46.57 }
                    },
                    new double[,]
                    {
                        { 2.43, -0.65, 49.61 },
                        { -4.72, 5.16, 24.02 },
                        { -30.58, 21.35, 32.69 }
                    });
            }
        }

        public static IEnumerable<TestCaseData> ValidArrayPairsWithSameSizeWithMultiplyResult
        {
            get
            {
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 11.16 }
                    },
                    new double[,]
                    {
                        { 51.47 }
                    },
                    new double[,]
                    {
                        { 574.4052 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 31.23 },
                        { 92.35 }
                    },
                    new double[,]
                    {
                        { 29.18 }
                    },
                    new double[,]
                    {
                        { 911.2914 },
                        { 2694.773 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 85.91 },
                        { 10.48 }
                    },
                    new double[,]
                    {
                        { 76.46, 98.31 }
                    },
                    new double[,]
                    {
                        { 6568.6786, 8445.8121 },
                        { 801.3008, 1030.2888 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 87.61 }
                    },
                    new double[,]
                    {
                        { 75.48, 13.99, 18.65, 21.96, 22.87, 65.95, 65.50 }
                    },
                    new double[,]
                    {
                        { 6612.8028, 1225.6639, 1633.9265, 1923.9156, 2003.6407, 5777.8795, 5738.455 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 81.58, 86.17, 30.04 }
                    },
                    new double[,]
                    {
                        { 15.04 },
                        { 24.03 },
                        { 63.92 }
                    },
                    new double[,]
                    {
                        { 5217.7851 }
                    });
                yield return new TestCaseData(
                    new double[,]
                    {
                        { 52.65 },
                        { 83.38 },
                        { 54.30 }
                    },
                    new double[,]
                    {
                        { 71.29, 55.23, 72.00 }
                    },
                    new double[,]
                    {
                        { 3753.4185, 2907.8595, 3790.8000 },
                        { 5944.1602, 4605.0774, 6003.3600 },
                        { 3871.0470, 2998.9890, 3909.6000 },
                    });
            }
        }
    }
}
