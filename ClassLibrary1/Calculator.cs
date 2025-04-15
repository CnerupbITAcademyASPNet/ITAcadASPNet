using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1
{
    /// <summary>
    /// Provides basic arithmetic operations with overloads for double, int, and string inputs.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two double values.
        /// </summary>
        /// <param name="x">The first double value.</param>
        /// <param name="y">The second double value.</param>
        /// <returns>The sum of x and y.</returns>
        public double Add(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <param name="x">The first integer value.</param>
        /// <param name="y">The second integer value.</param>
        /// <returns>The sum of x and y.</returns>
        public double Add(int x, int y)
        {
            return Add((double)x, (double)y);
        }

        /// <summary>
        /// Adds two string values after parsing them to double.
        /// </summary>
        /// <param name="x">The first value as a string.</param>
        /// <param name="y">The second value as a string.</param>
        /// <returns>The sum of the parsed values.</returns>
        /// <exception cref="FormatException">Thrown when x or y cannot be parsed to double.</exception>
        public double Add(string x, string y)
        {
            if (double.TryParse(x, out double xDouble) && double.TryParse(y, out double yDouble))
            {
                return Add(xDouble, yDouble);
            }
            else
            {
                throw new FormatException("Invalid x or y as strings");
            }
        }

        /// <summary>
        /// Subtracts the second double value from the first.
        /// </summary>
        /// <param name="x">The minuend (double).</param>
        /// <param name="y">The subtrahend (double).</param>
        /// <returns>The result of subtraction.</returns>
        public double Substract(double x, double y)
        {
            return x - y;
        }

        /// <summary>
        /// Subtracts the second integer from the first.
        /// </summary>
        /// <param name="x">The minuend (int).</param>
        /// <param name="y">The subtrahend (int).</param>
        /// <returns>The result of subtraction.</returns>
        public double Substract(int x, int y)
        {
            return Substract((double)x, (double)y);
        }

        /// <summary>
        /// Subtracts the second string value from the first after parsing them to double.
        /// </summary>
        /// <param name="x">The minuend as a string.</param>
        /// <param name="y">The subtrahend as a string.</param>
        /// <returns>The result of subtraction.</returns>
        /// <exception cref="FormatException">Thrown when x or y cannot be parsed to double.</exception>
        public double Substract(string x, string y)
        {
            if (double.TryParse(x, out double xDouble) && double.TryParse(y, out double yDouble))
            {
                return Substract(xDouble, yDouble);
            }
            else
            {
                throw new FormatException("Invalid x or y as strings");
            }
        }

        /// <summary>
        /// Multiplies two double values.
        /// </summary>
        /// <param name="x">The first double value.</param>
        /// <param name="y">The second double value.</param>
        /// <returns>The product of x and y.</returns>
        public double Multiply(double x, double y)
        {
            return x * y;
        }

        /// <summary>
        /// Multiplies two integers.
        /// </summary>
        /// <param name="x">The first integer value.</param>
        /// <param name="y">The second integer value.</param>
        /// <returns>The product of x and y.</returns>
        public double Multiply(int x, int y)
        {
            return Multiply((double)x, (double)y);
        }

        /// <summary>
        /// Multiplies two string values after parsing them to double.
        /// </summary>
        /// <param name="x">The first value as a string.</param>
        /// <param name="y">The second value as a string.</param>
        /// <returns>The product of the parsed values.</returns>
        /// <exception cref="FormatException">Thrown when x or y cannot be parsed to double.</exception>
        public double Multiply(string x, string y)
        {
            if (double.TryParse(x, out double xDouble) && double.TryParse(y, out double yDouble))
            {
                return Multiply(xDouble, yDouble);
            }
            else
            {
                throw new FormatException("Invalid x or y as strings");
            }
        }

        /// <summary>
        /// Divides the first double value by the second.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>The result of division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when y is zero.</exception>
        public double Divide(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException("y is 0");
            return x / y;
        }

        /// <summary>
        /// Divides the first integer by the second.
        /// </summary>
        /// <param name="x">The dividend.</param>
        /// <param name="y">The divisor.</param>
        /// <returns>The result of division.</returns>
        public double Divide(int x, int y)
        {
            return Divide((double)x, (double)y);
        }

        /// <summary>
        /// Divides the first string value by the second after parsing them to double.
        /// </summary>
        /// <param name="x">The dividend as a string.</param>
        /// <param name="y">The divisor as a string.</param>
        /// <returns>The result of division.</returns>
        /// <exception cref="FormatException">Thrown when x or y cannot be parsed to double.</exception>
        /// <exception cref="DivideByZeroException">Thrown when the parsed y is zero.</exception>
        public double Divide(string x, string y)
        {
            if (double.TryParse(x, out double xDouble) && double.TryParse(y, out double yDouble))
            {
                return Divide(xDouble, yDouble);
            }
            else
            {
                throw new FormatException("Invalid x or y as strings");
            }
        }

        /// <summary>
        /// Raises a double value to the power of an integer.
        /// </summary>
        /// <param name="val">The base value.</param>
        /// <param name="degree">The exponent.</param>
        /// <returns>The result of val raised to the power of degree.</returns>
        public double Power(double val, int degree)
        {
            if (val == 0)
            {
                if (degree < 0) throw new ArgumentOutOfRangeException("0 raised to the power of negative degree is division by zero");
                else if (degree == 0) throw new ArgumentOutOfRangeException("0 raised to the power of 0 is undefined.");
                else return 0;
            }

            if (val == 1) return 1;

            int nIter;
            if (degree < 0) nIter = degree * (-1);
            else nIter = degree;

            double result = 1;
            for (int i = 0; i < nIter; i++)
            {
                result *= val;
            }

            if (degree < 0) result = 1 / result;

            return result;
        }

        /// <summary>
        /// Raises an integer value to the power of another integer.
        /// </summary>
        /// <param name="val">The base value.</param>
        /// <param name="degree">The exponent.</param>
        /// <returns>The result of val raised to the power of degree.</returns>
        public double Power(int val, int degree)
        {
            double valDouble = (double)val;
            return Power(valDouble, degree);
        }

        /// <summary>
        /// Raises a string value to the power of another string after parsing them.
        /// </summary>
        /// <param name="val">The base value as a string.</param>
        /// <param name="degree">The exponent as a string.</param>
        /// <returns>The result of val raised to the power of degree.</returns>
        /// <exception cref="FormatException">Thrown when val or degree cannot be parsed correctly.</exception>
        public double Power(string val, string degree)
        {
            if (double.TryParse(val, out double valDouble) && int.TryParse(degree, out int degreeInt))
            {
                return Power(valDouble, degreeInt);
            }
            else
            {
                throw new FormatException("Invalid val or degree as strings");
            }
        }

        /// <summary>
        /// Calculates the square root of a double value using Heron's method.
        /// </summary>
        /// <param name="val">The value to find the square root of. Must be non-negative.</param>
        /// <param name="nIter">The number of iterations to approximate the root. Default is 10.</param>
        /// <returns>The approximate square root of the value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when val is less than 0.</exception>
        public double SquareRoot(double val, int nIter = 100)
        {
            if (val < 0) throw new ArgumentOutOfRangeException("val must be greater than 0");
            if (val == 0) return 0;

            double x0;
            if (val < 1) x0 = 1;
            else x0 = val / 2;

            double xCurrent = x0;
            double xNext;
            for (int i = 1; i < nIter; i++)
            {
                xNext = (xCurrent + (val / xCurrent)) / 2;
                xCurrent = xNext;
            }

            return double.Round(xCurrent, 2);
        }

        /// <summary>
        /// Calculates the square root of an integer using Heron's method.
        /// </summary>
        /// <param name="val">The integer value to find the square root of. Must be non-negative.</param>
        /// <returns>The approximate square root of the value.</returns>
        public double SquareRoot(int val)
        {
            double valDouble = (double)val;
            return SquareRoot(valDouble);
        }

        /// <summary>
        /// Calculates the square root of a string value parsed as double using Heron's method.
        /// </summary>
        /// <param name="val">The value as a string. Must represent a non-negative number.</param>
        /// <returns>The approximate square root of the value.</returns>
        /// <exception cref="FormatException">Thrown when val cannot be parsed to double.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the parsed value is less than 0.</exception>
        public double SquareRoot(string val)
        {
            if (double.TryParse(val, out double valDouble))
            {
                return SquareRoot(valDouble);
            }
            else
            {
                throw new FormatException("Invalid val as string");
            }
        }
    }

}
