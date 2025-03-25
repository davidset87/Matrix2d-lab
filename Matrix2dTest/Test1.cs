
using Matrix2dLib;

namespace MsTest
{
    [TestClass]
    public sealed class TestMatrix2d
    {
        [TestMethod]
        public void Test_Constructor_Default()
        {
            // Testowanie konstruktora domyślnego (powinna być macierz jednostkowa)
            var matrix = new Matrix2d();
            Assert.AreEqual(new Matrix2d(1, 0, 0, 1), matrix);
        }

        [TestMethod]
        public void Test_Constructor_Values()
        {
            // Testowanie konstruktora z parametrami
            var matrix = new Matrix2d(2, 3, 4, 5);
            Assert.AreEqual(2, matrix.Det());
        }

        [TestMethod]
        public void Test_Addition()
        {
            // Testowanie dodawania macierzy
            var m1 = new Matrix2d(1, 2, 3, 4);
            var m2 = new Matrix2d(5, 6, 7, 8);
            var expected = new Matrix2d(6, 8, 10, 12);

            Assert.AreEqual(expected, m1 + m2);
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            // Testowanie odejmowania macierzy
            var m1 = new Matrix2d(5, 6, 7, 8);
            var m2 = new Matrix2d(1, 2, 3, 4);
            var expected = new Matrix2d(4, 4, 4, 4);

            Assert.AreEqual(expected, m1 - m2);
        }

        [TestMethod]
        public void Test_Multiplication_Scalar()
        {
            // Testowanie mnożenia przez skalar
            var m = new Matrix2d(1, 2, 3, 4);
            var expected = new Matrix2d(2, 4, 6, 8);

            Assert.AreEqual(expected, 2 * m);
            Assert.AreEqual(expected, m * 2);
        }

        [TestMethod]
        public void Test_Negation()
        {
            // Testowanie negacji macierzy
            var m = new Matrix2d(1, -2, 3, -4);
            var expected = new Matrix2d(-1, 2, -3, 4);

            Assert.AreEqual(expected, -m);
        }

        [TestMethod]
        public void Test_Transpose()
        {
            // Testowanie transpozycji
            var m = new Matrix2d(1, 2, 3, 4);
            var expected = new Matrix2d(1, 3, 2, 4);

            Assert.AreEqual(expected, Matrix2d.Transpose(m));
        }

        [TestMethod]
        public void Test_Determinant()
        {
            // Testowanie wyznacznika
            var m = new Matrix2d(1, 2, 3, 4);
            int expectedDet = -2;

            Assert.AreEqual(expectedDet, m.Det());
        }

        [TestMethod]
        public void Test_Parse_Valid()
        {
            // Testowanie parsowania poprawnego łańcucha znaków
            var parsedMatrix = Matrix2d.Parse("[[2, 3], [4, 5]]");
            var expected = new Matrix2d(2, 3, 4, 5);

            Assert.AreEqual(expected, parsedMatrix);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Test_Parse_Invalid()
        {
            // Testowanie parsowania niepoprawnego łańcucha znaków (powinno rzucić wyjątek)
            Matrix2d.Parse("[[2, 3] [4, 5]]"); // Brakuje przecinka
        }
    }
}
