using SEDOL.Service.Interfaces;
using SEDOL.Service.Services;
using System;

namespace SEDOL.Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------- Welcome To SEDOL Checker --------------");

            var sedolValidator = new SedolValidator();

            do
            {
                RunSedolChecker(sedolValidator);
            }
            while (Console.ReadLine().Equals("y", StringComparison.OrdinalIgnoreCase));
        }

        public static void RunSedolChecker(ISedolValidator sedolValidator)
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please provide SEDOL to validate.");

            var inputString = Console.ReadLine();

            var validationResult = sedolValidator.ValidateSedol(inputString);

            Console.WriteLine("InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails");
            Console.WriteLine("---|--|--|--|");
            Console.WriteLine(validationResult.ToString());

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Do you wish to validate another SEDOL? (y/n) ");
        }
    }
}
