using System;
using System.Linq;

namespace Calculator
{
    public class Calc
    {
        public int Add(string numbers)
        {
            var delimiters = new[] { ",", "\n" };
            var numbersOnly = numbers;

            if (numbers.StartsWith("//"))
            {
                if (numbers.StartsWith("//["))
                    delimiters = new[] {numbers.Substring(3, numbers.IndexOf(']') - 3)};
                else
                    delimiters = new[] { numbers.Skip(2).First().ToString() };

                numbersOnly = new string(numbers.SkipWhile(c => c != '\n').ToArray());
            }

            var integers = numbersOnly
                            .Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToList();

            var negatives = integers.Where(x => x < 0).ToList();
            if (negatives.Any())
                throw new ArgumentOutOfRangeException("numbers", string.Format("Negatives not allowed ({0})", string.Join(",", negatives)));

            return integers
                        .Where(x => x <= 1000)
                        .Sum();
        }
    }
}
