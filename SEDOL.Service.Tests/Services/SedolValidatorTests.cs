using NUnit.Framework;
using SEDOL.Service.Interfaces;
using SEDOL.Service.Services;

namespace SEDOL.Service.Tests.Services
{
    [TestFixture]
    public class SedolValidatorTests
    {
        private ISedolValidator sedolValidator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            sedolValidator = new SedolValidator();
        }

        // **Scenario:**  Null, empty string or string other than 7 characters long
        [TestCase(null,         ExpectedResult = "|False|False|Input string was not 7-characters long", TestName = "Test Case #1, Null, empty string or string other than 7 characters long")]
        [TestCase("Null",       ExpectedResult = "Null|False|False|Input string was not 7-characters long", TestName = "Test Case #2, Null, empty string or string other than 7 characters long")]
        [TestCase("",           ExpectedResult = "|False|False|Input string was not 7-characters long", TestName = "Test Case #3, Null, empty string or string other than 7 characters long")]
        [TestCase("\"\"",       ExpectedResult = "\"\"|False|False|Input string was not 7-characters long", TestName = "Test Case #4, Null, empty string or string other than 7 characters long")]
        [TestCase("12",         ExpectedResult = "12|False|False|Input string was not 7-characters long", TestName = "Test Case #5, Null, empty string or string other than 7 characters long")]
        [TestCase("123456789",  ExpectedResult = "123456789|False|False|Input string was not 7-characters long", TestName = "Test Case #6, Null, empty string or string other than 7 characters long")]

        // **Scenario:**  Invalid Checksum non user defined SEDOL
        [TestCase("1234567",    ExpectedResult = "1234567|False|False|Checksum digit does not agree with the rest of the input", TestName = "Test Case #7, Invalid Checksum non user defined SEDOL")]

        // **Scenario:**  Valid non user define SEDOL
        [TestCase("0709954",    ExpectedResult = "0709954|True|False|Null", TestName = "Test Case #8, Valid non user define SEDOL")]
        [TestCase("B0YBKJ7",    ExpectedResult = "B0YBKJ7|True|False|Null", TestName = "Test Case #9, Valid non user define SEDOL")]

        // **Scenario** Invalid Checksum user defined SEDOL
        [TestCase("9123451",    ExpectedResult = "9123451|False|True|Checksum digit does not agree with the rest of the input", TestName = "Test Case #10, Invalid Checksum user defined SEDOL")]
        [TestCase("9ABCDE8",    ExpectedResult = "9ABCDE8|False|True|Checksum digit does not agree with the rest of the input", TestName = "Test Case #11, Invalid Checksum user defined SEDOL")]

        // **Scenario** Invaid characters found
        [TestCase("9123_51",    ExpectedResult = "9123_51|False|False|SEDOL contains invalid characters", TestName = "Test Case #12, Invaid characters found")]
        [TestCase("VA.CDE8",    ExpectedResult = "VA.CDE8|False|False|SEDOL contains invalid characters", TestName = "Test Case #13, Invaid characters found")]

        // **Scenario:** Valid user defined SEDOL
        [TestCase("9123458",    ExpectedResult = "9123458|True|True|Null", TestName = "Test Case #14, Valid user defined SEDOL")]
        [TestCase("9123458",    ExpectedResult = "9123458|True|True|Null", TestName = "Test Case #15, Valid user defined SEDOL")]
        public string ValidateSedol_Input_ShouldReturnExpectedResult(string input)
        {
            var validationResult = sedolValidator.ValidateSedol(input);

            var actualResult = validationResult.ToString();

            return actualResult;
        }
    }
}