using ClassLibrary1;

namespace TestProject1
{
    [TestClass]
    public sealed class CalculatorTest
    {
        private Calculator calculator = new Calculator();

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_DoubleValues_ReturnsCorrectResult()
        {
            double x = 3.2;
            double y = 5.5;

            double result = calculator.Add(x, y);

            Assert.AreEqual(8.7, result, 0.000001);
        }

        [TestMethod]
        public void Add_IntValues_ReturnsCorrectResult()
        {
            int x = 3;
            int y = 5;

            double result = calculator.Add(x, y);

            Assert.AreEqual(8, result, 0.000001);
        }

        [TestMethod]
        public void Add_StringValues_ReturnsCorrectResult()
        {
            string x = "3";
            string y = "5";

            double result = calculator.Add(x, y);

            Assert.AreEqual(8, result, 0.000001);
        }

        [TestMethod]
        public void Add_StringValues_ThrowsFormatException()
        {
            string x = "c3a";
            string y = "d5b";

            Assert.ThrowsException<FormatException>(() => calculator.Add(x, y));
        }

        [TestMethod]
        public void Substract_DoubleValues_ReturnsCorrectResult()
        {
            double x = 3.2;
            double y = 5.5;

            double result = calculator.Substract(x, y);

            Assert.AreEqual(-2.3, result, 0.000001);
        }

        [TestMethod]
        public void Substract_IntValues_ReturnsCorrectResult()
        {
            int x = 3;
            int y = 5;

            double result = calculator.Substract(x, y);

            Assert.AreEqual(-2, result, 0.000001);
        }

        [TestMethod]
        public void Substract_StringValues_ReturnsCorrectResult()
        {
            string x = "3";
            string y = "5";

            double result = calculator.Substract(x, y);

            Assert.AreEqual(-2, result, 0.000001);
        }

        [TestMethod]
        public void Substract_StringValues_ThrowsFormatException()
        {
            string x = "c3a";
            string y = "d5b";

            Assert.ThrowsException<FormatException>(() => calculator.Substract(x, y));
        }

        [TestMethod]
        public void Multiply_DoubleValues_ReturnsCorrectResult()
        {
            double x = 3.2;
            double y = 5.5;

            double result = calculator.Multiply(x, y);

            Assert.AreEqual(17.6, result, 0.000001);
        }

        [TestMethod]
        public void Multiply_IntValues_ReturnsCorrectResult()
        {
            int x = 3;
            int y = 5;

            double result = calculator.Multiply(x, y);

            Assert.AreEqual(15, result, 0.000001);
        }

        [TestMethod]
        public void Multiply_StringValues_ReturnsCorrectResult()
        {
            string x = "3";
            string y = "5";

            double result = calculator.Multiply(x, y);

            Assert.AreEqual(15, result, 0.000001);
        }

        [TestMethod]
        public void Multiply_StringValues_ThrowsFormatException()
        {
            string x = "c3a";
            string y = "d5b";

            Assert.ThrowsException<FormatException>(() => calculator.Multiply(x, y));
        }

        [TestMethod]
        public void Division_DoubleValues_ReturnsCorrectResult()
        {
            double x = 3.2;
            double y = 5.5;

            double result = calculator.Multiply(x, y);

            Assert.AreEqual(17.6, result, 0.000001);
        }

        [TestMethod]
        public void Division_IntValues_ReturnsCorrectResult()
        {
            int x = 3;
            int y = 5;

            double result = calculator.Divide(x, y);

            Assert.AreEqual(0.6, result, 0.000001);
        }

        [TestMethod]
        public void Division_StringValues_ReturnsCorrectResult()
        {
            string x = "3";
            string y = "5";

            double result = calculator.Divide(x, y);

            Assert.AreEqual(0.6, result, 0.000001);
        }

        [TestMethod]
        public void Division_DoubleValues_ThrowsDivisionByZero()
        {
            double x = 3.2;
            double y = 0;

            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(x, y));
        }

        [TestMethod]
        public void Division_IntValues_ThrowsDivisionByZero()
        {
            int x = 3;
            int y = 0;

            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(x, y));
        }

        [TestMethod]
        public void Division_StringValues_ThrowsDivisionByZero()
        {
            string x = "3";
            string y = "0";

            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(x, y));
        }

        [TestMethod]
        public void Division_StringValues_ThrowsFormatException()
        {
            string x = "3a";
            string y = "b5";

            Assert.ThrowsException<FormatException>(() => calculator.Divide(x, y));
        }

        [TestMethod]
        public void Power_DoubleValues_ReturnsCorrectResult()
        {
            double x = 4.4;
            int degree = 3;

            double result = calculator.Power(x, degree);
            Assert.AreEqual(85.184, result, 0.000001);
        }

        [TestMethod]
        public void Power_IntValues_ReturnsCorrectResult()
        {
            int x = 4;
            int degree = 3;

            double result = calculator.Power(x, degree);
            Assert.AreEqual(64, result, 0.000001);
        }

        [TestMethod]
        public void Power_StringValues_ReturnsCorrectResult()
        {
            string x = "4";
            string degree = "3";

            double result = calculator.Power(x, degree);
            Assert.AreEqual(64, result, 0.000001);
        }

        [TestMethod]
        public void Power_IntValues_NegativeDegree_ReturnsCorrectResult()
        {
            int x = 4;
            int degree = -2;

            double result = calculator.Power(x, degree);
            Assert.AreEqual(0.0625, result, 0.000001);
        }

        [TestMethod]
        public void Power_IntZeroX_ThrowsArgumentOutOfRangeException_OnNegativeDegree()
        {
            int x = 0;
            int degree = -2;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculator.Power(x, degree));
        }

        [TestMethod]
        public void Power_IntZeroValues_ThrowsArgumentOutOfRangeException()
        {
            int x = 0;
            int degree = 0;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculator.Power(x, degree));
        }

        [TestMethod]
        public void SquareRoot_DoubleValue_ReturnsCorrectResult()
        {
            double x = 8;

            double result = calculator.SquareRoot(x);

            Assert.AreEqual(2.83, result, 0.000001);
        }

        [TestMethod]
        public void SquareRoot_IntValue_ReturnsCorrectResult()
        {
            int x = 8;

            double result = calculator.SquareRoot(x);

            Assert.AreEqual(2.83, result, 0.000001);
        }

        [TestMethod]
        public void SquareRoot_StringValue_ReturnsCorrectResult()
        {
            string x = "8";

            double result = calculator.SquareRoot(x);

            Assert.AreEqual(2.83, result, 0.000001);
        }

        [TestMethod]
        public void SquareRoot_StringValue_ThrowsFormatException()
        {
            string x = "c3a";

            Assert.ThrowsException<FormatException>(() => calculator.SquareRoot(x));
        }

        [TestMethod]
        public void SquareRoot_StringValue_ThrowsArgumentOutOfRangeException()
        {
            string x = "-1";

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => calculator.SquareRoot(x));
        }


    }
}
