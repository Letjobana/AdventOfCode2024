namespace AdventOfCode2024.Days.Day1
{
    public class Day1
    {
        public static void Part1()
        {
            var lines = File.ReadAllLines("Days/Day1/input.txt");
            int sum = lines.Sum(line => ExtractCalibrationValue(line));
            Console.WriteLine("Sum of all calibration values: " + sum);
        }

        private static int ExtractCalibrationValue(string line)
        {
            char firstDigit = line.FirstOrDefault(char.IsDigit);
            char lastDigit = line.LastOrDefault(char.IsDigit);
            string twoDigitNumberStr = firstDigit.ToString() + lastDigit.ToString();
            return int.Parse(twoDigitNumberStr);
        }
    }
}
