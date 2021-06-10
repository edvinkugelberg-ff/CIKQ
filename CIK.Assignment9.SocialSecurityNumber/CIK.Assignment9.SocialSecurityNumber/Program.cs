using CIK.Assignment9.SocialSecurityNumber.Models;
using System;
using System.Collections.Generic;

namespace CIK.Assignment9.SocialSecurityNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User!");

            var ssn = "811218-9876";

            ssn = TrimSsn(ssn, new List<string> { "-", "/", " " });

            var parsedSsn = ParseSsn(ssn);

            if(parsedSsn == null)
            {
                Console.WriteLine("Could not parse social security number, please check input");
                return;
            }

            var isValidSsn = ValidateUniqueIdentifierNumbers(parsedSsn);

            Console.WriteLine(isValidSsn);
        }

        static bool ValidateUniqueIdentifierNumbers(SocialSecurityNumberParts ssn)
        {
            var firstNine = $"{ssn.Date.ToString("yyMMdd")}{ssn.UniqueIdentifier.Substring(0, 3)}";
            var checkNumber = ssn.UniqueIdentifier.Substring(3, 1);

            var isValidLuhn = LuhnChecker.Check(firstNine, checkNumber);

            return isValidLuhn;
        }

        static string TrimSsn(string ssn, List<string> deviders)
        {
            var trimmedSsn = ssn;

            foreach (var character in deviders)
            {
                trimmedSsn = trimmedSsn.Replace(character, "");
            }

            return trimmedSsn;
        }

        static SocialSecurityNumberParts ParseSsn(string ssn)
        {

            var partedSocialSecurityNumber = new SocialSecurityNumberParts();

            string longYear;
            string month;
            string day;
            try
            {
                if(ssn.Length == 10)
                {
                    var shortYear = int.Parse(ssn.Substring(0, 2));
                    
                    if( shortYear > (DateTime.UtcNow.Year % 100))
                    {
                        longYear = "19" + shortYear;
                    }
                    else
                    {
                        longYear = "20" + shortYear;
                    }

                    month = ssn.Substring(2, 2);
                    day = ssn.Substring(4, 2);
                    partedSocialSecurityNumber.UniqueIdentifier = ssn.Substring(6, 4);
                }
                else if(ssn.Length == 12)
                {
                    longYear = ssn.Substring(0, 4);
                    month = ssn.Substring(4, 2);
                    day = ssn.Substring(6, 2);
                    partedSocialSecurityNumber.UniqueIdentifier = ssn.Substring(8, 4);
                }
                else
                {
                    return null;
                }

                var successfullyParsedDate = DateTime.TryParse($"{longYear}-{month}-{day}", out var dateOfBirth);

                if (successfullyParsedDate)
                {
                    partedSocialSecurityNumber.Date = dateOfBirth;
                    return partedSocialSecurityNumber;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
