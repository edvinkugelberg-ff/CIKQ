using System.Collections.Generic;

namespace CIK.Assignment9.SocialSecurityNumber
{
    public class LuhnChecker
    {
        public static bool Check(string firstNine, string checkNumber)
        {
            var numbers = new List<int>();

            foreach (var number in firstNine.ToCharArray())
            {
                numbers.Add(int.Parse(number.ToString()));
            }

            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];
                var partSum = 0;

                if ((i + 1) % 2 == 0)
                {
                    partSum = number * 1;
                }
                else
                {
                    partSum = number * 2;
                }

                var powerOne = partSum % 10;
                sum = sum + powerOne;

                if (partSum > 9)
                {
                    sum = sum + 1;
                }
            }

            var totalSum = sum + int.Parse(checkNumber);

            return (totalSum % 10 == 0);
        }
    }
}