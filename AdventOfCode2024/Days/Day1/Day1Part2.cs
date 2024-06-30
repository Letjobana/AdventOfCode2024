using System.Text.RegularExpressions;

namespace AdventOfCode2024.Days.Day1
{
    public class Day1Part2
    {
        private static readonly Dictionary<string, int> NumberMap = new Dictionary<string, int>
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };

        public static void Execute()
        {
            var lines = File.ReadAllLines("Days/Day1/input.txt");
            int sum = lines.Sum(line => ExtractCalibrationValue(line));
            Console.WriteLine("Sum of all calibration values: " + sum);
        }

        private static int ExtractCalibrationValue(string line)
        {
            string firstDigitStr = ExtractFirstDigitString(line);
            string lastDigitStr = ExtractLastDigitString(line);

            int firstDigit = ConvertToDigit(firstDigitStr);
            int lastDigit = ConvertToDigit(lastDigitStr);

            string twoDigitNumberStr = firstDigit.ToString() + lastDigit.ToString();
            return int.Parse(twoDigitNumberStr);
        }

        private static string ExtractFirstDigitString(string line)
        {
            // Find the first occurrence of a digit or spelled-out number
            var match = Regex.Match(line, @"\d|zero|one|two|three|four|five|six|seven|eight|nine");
            return match.Value;
        }

        private static string ExtractLastDigitString(string line)
        {
            // Find the last occurrence of a digit or spelled-out number
            var matches = Regex.Matches(line, @"\d|zero|one|two|three|four|five|six|seven|eight|nine");
            return matches.Count > 0 ? matches[matches.Count - 1].Value : string.Empty;
        }

        private static int ConvertToDigit(string digitStr)
        {
            if (int.TryParse(digitStr, out int digit))
            {
                return digit;
            }

            return NumberMap[digitStr.ToLower()];
        }
    }
}
