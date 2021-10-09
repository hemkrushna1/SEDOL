namespace SEDOL.Service.Models
{
    /// <summary>
    /// SEDOL Validation Result class.
    /// </summary>
    public class ValidationResult : ISedolValidationResult
    {
        /// <summary>
        /// Gets and sets the input string.
        /// </summary>
        /// <value>
        /// The input string.
        /// </value>
        public string InputString { get; set; }

        /// <summary>
        /// Gets and sets a value indicating whether the input string is a valid SEDOL.
        /// </summary>
        /// <value>
        /// <c>true</c> if the input string is a valid SEDOL; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidSedol { get; set; }

        /// <summary>
        /// Gets and sets a value indicating whether the input string represents a user defined SEDOL.
        /// </summary>
        /// <value>
        /// <c>true</c> if the input string represents a user defined SEDOL; otherwise, <c>false</c>.
        /// </value>
        public bool IsUserDefined { get; set; }

        /// <summary>
        /// Gets and sets the validation details such as root cause of validation failure.
        /// </summary>
        /// <value>
        /// The validation details.
        /// </value>
        public string ValidationDetails { get; set; }

        /// <summary>
        /// Format ValidationResult so it will be useful in result and unit test
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{InputString}|{IsValidSedol}|{IsUserDefined}|{ValidationDetails}";
        }
    }
}
