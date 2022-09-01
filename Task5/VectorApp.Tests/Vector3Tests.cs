using NUnit.Framework;

namespace VectorApp.Tests
{
    public class Vector3Tests
    {
        [TestCase(new[] { 1d, 2d, 3d }, new[] { 3d, 2d, 1d }, new[] { 4d, 4d, 4d })]
        [TestCase(new[] { 33.56, 76.34, 86.34 }, new[] { 76.45, 23.54, 65.23 }, new[] { 110.01, 99.88, 151.57 })]
        [TestCase(new[] { 29.48, 84.80, 93.34 }, new[] { 90.23, 26.61, 62.86 }, new[] { 119.71, 111.41, 156.20 })]
        [TestCase(new[] { 12.65, 26.39, 87.46 }, new[] { 28.64, 41.02, 29.56 }, new[] { 41.29, 67.41, 117.02 })]
        [TestCase(new[] { 54.52, 83.73, 58.83 }, new[] { 17.57, 50.82, 13.68 }, new[] { 72.09, 134.55, 72.51 })]
        [TestCase(new[] { 769.437, 398.731, 102.273 }, new[] { 556.834, 209.052, 281.480 }, new[] { 1326.271, 607.783, 383.753 })]
        [TestCase(new[] { 538.978, 627.223, 880.288 }, new[] { 598.800, 128.606, 258.214 }, new[] { 1137.778, 755.829, 1138.502 })]
        [TestCase(new[] { 375.634, 249.874, 689.909 }, new[] { 397.928, 407.695, 273.148 }, new[] { 773.562, 657.569, 963.057 })]
        [TestCase(new[] { 206783.473311, 154307.510737, 535279.828830 }, new[] { 443494.481376, 335886.407824, 188110.767094 }, new[] { 650277.954687, 490193.918561, 723390.595924 })]
        public void Add(double[] lhsCoords, double[] rhsCoords, double[] expectedCoords)
        {
            var expected = new Vector3(expectedCoords[0], expectedCoords[1], expectedCoords[2]);

            var actual = new Vector3(lhsCoords[0], lhsCoords[1], lhsCoords[2]) + new Vector3(rhsCoords[0], rhsCoords[1], rhsCoords[2]);

            Assert.AreEqual(expected.X, actual.X, 1E-9);
            Assert.AreEqual(expected.Y, actual.Y, 1E-9);
            Assert.AreEqual(expected.Z, actual.Z, 1E-9);
        }

        [TestCase(new[] { 1d, 2d, 3d }, new[] { 3d, 2d, 1d }, new[] { -2d, 0d, 2d })]
        [TestCase(new[] { 33.56, 76.34, 86.34 }, new[] { 76.45, 23.54, 65.23 }, new[] { -42.89, 52.8, 21.11 })]
        [TestCase(new[] { 29.48, 84.80, 93.34 }, new[] { 90.23, 26.61, 62.86 }, new[] { -60.75, 58.19, 30.48 })]
        [TestCase(new[] { 12.65, 26.39, 87.46 }, new[] { 28.64, 41.02, 29.56 }, new[] { -15.99, -14.63, 57.9 })]
        [TestCase(new[] { 54.52, 83.73, 58.83 }, new[] { 17.57, 50.82, 13.68 }, new[] { 36.95, 32.91, 45.15 })]
        [TestCase(new[] { 769.437, 398.731, 102.273 }, new[] { 556.834, 209.052, 281.480 }, new[] { 212.603, 189.679, -179.207 })]
        [TestCase(new[] { 538.978, 627.223, 880.288 }, new[] { 598.800, 128.606, 258.214 }, new[] { -59.822, 498.617, 622.074 })]
        [TestCase(new[] { 375.634, 249.874, 689.909 }, new[] { 397.928, 407.695, 273.148 }, new[] { -22.294, -157.821, 416.761 })]
        [TestCase(new[] { 206783.473311, 154307.510737, 535279.828830 }, new[] { 443494.481376, 335886.407824, 188110.767094 }, new[] { -236711.008065, -181578.897087, 347169.061736 })]
        public void Substruct(double[] lhsCoords, double[] rhsCoords, double[] expectedCoords)
        {
            var expected = new Vector3(expectedCoords[0], expectedCoords[1], expectedCoords[2]);

            var actual = new Vector3(lhsCoords[0], lhsCoords[1], lhsCoords[2]) - new Vector3(rhsCoords[0], rhsCoords[1], rhsCoords[2]);

            Assert.AreEqual(expected.X, actual.X, 1E-9);
            Assert.AreEqual(expected.Y, actual.Y, 1E-9);
            Assert.AreEqual(expected.Z, actual.Z, 1E-9);
        }

        [TestCase(new[] { 1d, 2d, 3d }, new[] { 3d, 2d, 1d }, 10d)]
        [TestCase(new[] { 33.56, 76.34, 86.34 }, new[] { 76.45, 23.54, 65.23 }, 9994.6638)]
        [TestCase(new[] { 29.48, 84.80, 93.34 }, new[] { 90.23, 26.61, 62.86 }, 10783.8608)]
        [TestCase(new[] { 12.65, 26.39, 87.46 }, new[] { 28.64, 41.02, 29.56 }, 4030.1314)]
        [TestCase(new[] { 54.52, 83.73, 58.83 }, new[] { 17.57, 50.82, 13.68 }, 6017.8694)]
        [TestCase(new[] { 769.437, 398.731, 102.273 }, new[] { 556.834, 209.052, 281.480 }, 540591.99951)]
        [TestCase(new[] { 538.978, 627.223, 880.288 }, new[] { 598.800, 128.606, 258.214 }, 630707.35317)]
        [TestCase(new[] { 375.634, 249.874, 689.909 }, new[] { 397.928, 407.695, 273.148 }, 439794.930314)]
        [TestCase(new[] { 206783.473311, 154307.510737, 535279.828830 }, new[] { 443494.481376, 335886.407824, 188110.767094 }, 2.44229023946060439882244E+11)]
        public void DotProduct(double[] lhsCoords, double[] rhsCoords, double expected)
        {
            var actual = new Vector3(lhsCoords[0], lhsCoords[1], lhsCoords[2]) * new Vector3(rhsCoords[0], rhsCoords[1], rhsCoords[2]);

            Assert.AreEqual(expected, actual, 1E-9);
        }

        [TestCase(new[] { 1d, 2d, 3d }, new[] { 3d, 2d, 1d }, new[] { -4d, 8d, -4d })]
        [TestCase(new[] { 33.56, 76.34, 86.34 }, new[] { 76.45, 23.54, 65.23 }, new[] { 2947.2146, 4411.5742, -5046.1906 })]
        [TestCase(new[] { 29.48, 84.80, 93.34 }, new[] { 90.23, 26.61, 62.86 }, new[] { 2846.7506, 6568.9554, -6867.0412 })]
        [TestCase(new[] { 12.65, 26.39, 87.46 }, new[] { 28.64, 41.02, 29.56 }, new[] { -2807.5208, 2130.9204, -236.9066 })]
        [TestCase(new[] { 54.52, 83.73, 58.83 }, new[] { 17.57, 50.82, 13.68 }, new[] { -1844.3142, 287.8095, 1299.5703 })]
        [TestCase(new[] { 769.437, 398.731, 102.273 }, new[] { 556.834, 209.052, 281.480 }, new[] { 90854.426684, -159632.043078, -61174.63393 })]
        [TestCase(new[] { 538.978, 627.223, 880.288 }, new[] { 598.800, 128.606, 258.214 }, new[] { 48747.441194, 387944.789108, -306265.327732 })]
        [TestCase(new[] { 375.634, 249.874, 689.909 }, new[] { 397.928, 407.695, 273.148 }, new[] { -213019.866403, 171930.43272, 53712.242558 })]
        [TestCase(new[] { 20783.473311, 15437.510737, 53579.828830 }, new[] { 443494.481376, 335886.407824, 188110.767094 }, new[] { -15092774250.77456, 19852763291.765816, 134435374.49551964 })]
        public void CrossProduct(double[] lhsCoords, double[] rhsCoords, double[] expectedCoords)
        {
            var expected = new Vector3(expectedCoords[0], expectedCoords[1], expectedCoords[2]);

            var actual = new Vector3(lhsCoords[0], lhsCoords[1], lhsCoords[2]) & new Vector3(rhsCoords[0], rhsCoords[1], rhsCoords[2]);

            Assert.AreEqual(expected.X, actual.X, 1E-9);
            Assert.AreEqual(expected.Y, actual.Y, 1E-9);
            Assert.AreEqual(expected.Z, actual.Z, 1E-9);
        }

        [TestCase(new[] { 1d, 2d, 3d }, 6d, new[] { 6d, 12d, 18d })]
        [TestCase(new[] { 3d, 2d, 1d }, 2d, new[] { 6d, 4d, 2d })]
        [TestCase(new[] { 33.56, 76.34, 86.34 }, 64.84, new[] { 2176.0304, 4949.8856, 5598.2856 })]
        [TestCase(new[] { 29.48, 84.80, 93.34 }, 60.07, new[] { 1770.8636, 5093.936, 5606.9338 })]
        [TestCase(new[] { 12.65, 26.39, 87.46 }, 71.18, new[] { 900.427, 1878.4402, 6225.4028 })]
        [TestCase(new[] { 54.52, 83.73, 58.83 }, 25.19, new[] { 1373.3588, 2109.1587, 1481.9277 })]
        [TestCase(new[] { 76.45, 23.54, 65.23 }, 31.99, new[] { 2445.6355, 753.0446, 2086.7077 })]
        [TestCase(new[] { 90.23, 26.61, 62.86 }, 55.08, new[] { 4969.8684, 1465.6788, 3462.3288 })]
        [TestCase(new[] { 28.64, 41.02, 29.56 }, 15.65, new[] { 448.216, 641.963, 462.614 })]
        [TestCase(new[] { 17.57, 50.82, 13.68 }, 95.20, new[] { 1672.664, 4838.064, 1302.336 })]
        [TestCase(new[] { 769.437, 398.731, 102.273 }, 294.416, new[] { 226534.563792, 117392.786096, 30110.807568 })]
        [TestCase(new[] { 538.978, 627.223, 880.288 }, 639.474, new[] { 344662.417572, 401092.800702, 562921.288512 })]
        [TestCase(new[] { 375.634, 249.874, 689.909 }, 402.160, new[] { 151064.96944, 100489.32784, 277453.80344 })]
        [TestCase(new[] { 556.834, 209.052, 281.480 }, 828.904, new[] { 461561.929936, 173284.039008, 233319.89792 })]
        [TestCase(new[] { 598.800, 128.606, 258.214 }, 304.409, new[] { 182280.1092, 39148.823854, 78602.665526 })]
        [TestCase(new[] { 397.928, 407.695, 273.148 }, 718.987, new[] { 286105.058936, 293127.404965, 196389.861076 })]
        [TestCase(new[] { 206783.473311, 154307.510737, 535279.828830 }, 3.4, new[] { 703063.8092574, 524645.5365058, 1819951.418022 })]
        [TestCase(new[] { 443494.481376, 335886.407824, 188110.767094 }, 7.9, new[] { 3503606.4028704, 2653502.6218096, 1486075.0600426 })]
        public void Scale(double[] vectorCoords, double scalar, double[] expectedCoords)
        {
            var expected = new Vector3(expectedCoords[0], expectedCoords[1], expectedCoords[2]);

            var actual = new Vector3(vectorCoords[0], vectorCoords[1], vectorCoords[2]) * scalar;

            Assert.AreEqual(expected.X, actual.X, 1E-9);
            Assert.AreEqual(expected.Y, actual.Y, 1E-9);
            Assert.AreEqual(expected.Z, actual.Z, 1E-9);
        }

        [TestCase(new[] { 1d, 2d, 3d }, 3.7416573867739413)]
        [TestCase(new[] { 3d, 2d, 1d }, 3.7416573867739413)]
        [TestCase(new[] { 33.56, 76.34, 86.34 }, 120.03609790392223)]
        [TestCase(new[] { 29.48, 84.80, 93.34 }, 129.50855570193036)]
        [TestCase(new[] { 12.65, 26.39, 87.46 }, 92.2263855954466)]
        [TestCase(new[] { 54.52, 83.73, 58.83 }, 115.94874816055584)]
        [TestCase(new[] { 76.45, 23.54, 65.23 }, 103.21669923030866)]
        [TestCase(new[] { 90.23, 26.61, 62.86 }, 113.14117110937114)]
        [TestCase(new[] { 28.64, 41.02, 29.56 }, 58.109238508175274)]
        [TestCase(new[] { 17.57, 50.82, 13.68 }, 55.4844095219549)]
        [TestCase(new[] { 769.437, 398.731, 102.273 }, 872.62791260594)]
        [TestCase(new[] { 538.978, 627.223, 880.288 }, 1207.8132882018645)]
        [TestCase(new[] { 375.634, 249.874, 689.909 }, 824.3253884923113)]
        [TestCase(new[] { 556.834, 209.052, 281.480 }, 658.0257082059941)]
        [TestCase(new[] { 598.800, 128.606, 258.214 }, 664.6618787263191)]
        [TestCase(new[] { 397.928, 407.695, 273.148 }, 631.8003926185864)]
        [TestCase(new[] { 206783.473311, 154307.510737, 535279.828830 }, 594217.7276526548)]
        [TestCase(new[] { 443494.481376, 335886.407824, 188110.767094 }, 587275.6547555593)]
        public void Length(double[] vectorCoords, double expected)
        {
            var actual = new Vector3(vectorCoords[0], vectorCoords[1], vectorCoords[2]).Length();

            Assert.AreEqual(expected, actual, 1E-9);
        }
    }
}