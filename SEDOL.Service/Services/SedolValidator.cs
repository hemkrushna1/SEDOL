using SEDOL.Service.Interfaces;
using SEDOL.Service.Models;
using System;
using System.Linq;
using static SEDOL.Service.Constants;

namespace SEDOL.Service.Services
{
    /// <summary>
    /// Class representing SEDOL validator.
    /// </summary>
    public class SedolValidator : ISedolValidator
    {
        /// <inheritdoc />
        public ISedolValidationResult ValidateSedol(string input)
        {
            string validationMessage = null;
            var isCorrectChecksum = false;
            var isUserDefinedSedol = false;

            // Not added validation on 7th char as it is not mentioned in question
            // but it required a validation to check values as it should be a digit only

            // **Scenario:**  Null, empty string or string other than 7 characters long
            if (string.IsNullOrWhiteSpace(input) || input.Length != 7)
            {
                validationMessage = ValidationMessage.InvalidInput;
            }
            // **Scenario** Invaid characters found
            else if (input.Any(ch => !Char.IsLetterOrDigit(ch)))
            {
                validationMessage = ValidationMessage.InvalidChars;
            }

            // if input string is correct as required for SEDOL
            if (string.IsNullOrEmpty(validationMessage))
            {
                // calculate check sum digit
                var checksum = SedolCheckSumCalculate(input);

                // check last digit from input with calculated checksum
                isCorrectChecksum = Char.GetNumericValue(input[input.Length - 1]).Equals(checksum);

                // The first character of a user defined SEDOL is a 9.
                isUserDefinedSedol = input.Substring(0, 1).Equals(Constants.UserDefinedFirstChar);

                // validation message as per validated checksum
                validationMessage = isCorrectChecksum ? ValidationMessage.ValidChecksum : ValidationMessage.InvalidChecksum;
            }

            return new ValidationResult
            {
                InputString = input,
                IsValidSedol = isCorrectChecksum,
                IsUserDefined = isUserDefinedSedol,
                ValidationDetails = validationMessage
            };
        }

        /// <summary>
        /// To calculate and return check sum digit
        /// </summary>
        /// <param name="input"></param>
        /// <returns>int</returns>
        private static int SedolCheckSumCalculate(string input)
        {
            var chars = input.ToCharArray();
            var sum = 0;

            for (int i = 0; i < input.Length - 1; i++)
            {
                sum += Char.IsLetter(chars[i])
                    ? ((Char.ToUpper(chars[i]) - Constants.ASCIICharNumExtra) * Constants.SedolWeightFactor[i])
                    : ((int)Char.GetNumericValue(chars[i]) * Constants.SedolWeightFactor[i]);
            }

            var checksum = (10 - (sum % 10)) % 10;

            return checksum;
        }
    }
}
