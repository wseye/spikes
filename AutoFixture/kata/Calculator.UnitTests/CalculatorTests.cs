using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calc _calculator;

        [SetUp]
        public void BeforeEachTest()
        {
            _calculator = new Calc();
        }

        [Test]
        public void AddEmptyStringReturnsCorrectResult()
        {
            int actual = _calculator.Add("");
            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void AddOneNumberReturnsCorrectResult()
        {
            const int x = 5;
            var numbers = string.Format("{0}", x);
            int actual = _calculator.Add(numbers);
            Assert.That(actual, Is.EqualTo(x));
        }

        [Test]
        public void AddTwoNumbersReturnsCorrectResult()
        {
            const int x = 5;
            const int y = 7;
            var numbers = string.Format("{0},{1}", x, y);
            int actual = _calculator.Add(numbers);
            Assert.That(actual, Is.EqualTo(x + y));
        }

        [Test]
        public void AddingAnyNumbersReturnsCorrectResult()
        {
            var integers = new[] {3,7,8,5};
            var numbers = string.Join(",", integers);

            int actual = _calculator.Add(numbers);
            int expected = integers.Sum();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddWithLineBreakAndCommaAsDelimitersReturnsCorrectResult()
        {
            const int x = 5;
            const int y = 7;
            const int z = 3;

            var numbers = string.Format("{0}\n{1},{2}", x, y, z);
            int actual = _calculator.Add(numbers);

            Assert.That(actual, Is.EqualTo(x + y + z));
        }

        [Test]
        public void AddLineWithCustomDelimiterReturnsCorrectResult()
        {
            const char delimiter = ';';
            var integers = new[] { 3, 7, 8, 5 };
            var numbers = string.Format("//{0}\n{1}", delimiter, string.Join(delimiter.ToString(), integers));

            var actual = _calculator.Add(numbers);
            var expected = integers.Sum();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void AddWithNegativeNumbersThrowsCorrectException()
        {
            const int x = 5;
            const int y = 7;
            const int z = 3;

            var numbers = string.Format("{0}\n{1},{2}", -x, y, -z);
            var e = Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Add(numbers));

            Assert.That(e.Message.StartsWith("Negatives not allowed"), "unexpected exception message");
            Assert.That(e.Message.Contains((-x).ToString()), "exception message should contain -x");
            Assert.That(e.Message.Contains((-z).ToString()), "exception message should contain -z");
        }

        [Test]
        public void AddIgnoresNumbersBiggerThan1000()
        {
            const int x = 2;
            const int y = 1001;

            var numbers = string.Format("{0},{1}", x, y);
            var actual = _calculator.Add(numbers);

            Assert.That(actual, Is.EqualTo(2));
        }

        [Test]
        public void CustomDelimiterCanBeOfAnySize()
        {
            const string delimiter = "*;,";
            var integers = new[] { 3, 7, 8, 5 };
            var numbers = string.Format("//[{0}]\n{1}", delimiter, string.Join(delimiter, integers));

            var actual = _calculator.Add(numbers);
            var expected = integers.Sum();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
