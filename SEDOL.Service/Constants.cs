namespace SEDOL.Service
{
    /// <summary>
    /// All constants defined in the system
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The first character of a user defined SEDOL is a 9.
        /// </summary>
        public static string UserDefinedFirstChar = "9";

        /// <summary>
        /// ASCII capital letters starting with 65, and in SEODL it is starting from 10.
        /// So, to get/calculate actual value of alphabet as per SEODL A => 65 - 10 = 55 
        /// </summary>
        public static int ASCIICharNumExtra = 55;

        /// <summary>
        /// ASCII capital letters starting with 65, and in SEODL it is starting from 10.
        /// So, to get/calculate actual value of alphabet as per SEODL A => 65 - 10 = 55 
        /// </summary>
        public static int ASCIINumExtra = 48;

        /// <summary>
        /// First:  1; Second: 3; Third: 1; Fourth: 7; Fifth: 3; Sixth: 9; Seventh: 1 (the check digit)
        /// </summary>
        public static int[] SedolWeightFactor = { 1, 3, 1, 7, 3, 9 };

        /// <summary>
        /// All validation messages defined in the system
        /// </summary>
        public static class ValidationMessage
        {
            /// <summary>
            /// **Scenario:** Null, empty string or string other than 7 characters long
            /// </summary>
            public static string InvalidInput = "Input string was not 7-characters long";

            /// <summary>
            /// **Scenario:** 1. Invalid Checksum non user defined SEDOL
            /// **Scenario:** 2. Invalid Checksum user defined SEDOL
            /// </summary>
            public static string InvalidChecksum = "Checksum digit does not agree with the rest of the input";

            /// <summary>
            /// **Scenario:** 1. Valid non user define SEDOL
            /// **Scenario:** 2. Valid user defined SEDOL
            /// </summary>
            public static string ValidChecksum = "Null";

            /// <summary>
            /// **Scenario:** Invaid characters found
            /// </summary>
            public static string InvalidChars = "SEDOL contains invalid characters";
        }
    }
}
