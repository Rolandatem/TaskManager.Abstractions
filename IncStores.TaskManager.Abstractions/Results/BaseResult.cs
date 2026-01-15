namespace IncStores.TaskManager.Results
{
    public abstract class BaseResult : IResult
    {
        #region "Constructors"
        /// <summary>
        /// Default constructor that automatically sets IsSuccessful and
        /// IsValid to true.
        /// </summary>
        public BaseResult()
        {
            this.IsSuccessful = true;
            this.IsValid = true;
        }

        /// <summary>
        /// Constructor with full issuccessful/isvalid control.
        /// </summary>
        /// <param name="isSuccessful">Sets whether the process was successful.</param>
        /// <param name="isValid">Sets whether the setup was correct.</param>
        public BaseResult(bool isSuccessful = true, bool isValid = true)
        {
            this.IsSuccessful = isSuccessful;
            this.IsValid = isValid;
        }

        /// <summary>
        /// Constructor with full control of base properties.
        /// </summary>
        /// <param name="isSuccessful">Sets whether the process was successful.</param>
        /// <param name="isValid">Sets whether the setup was correct.</param>
        /// <param name="message">An optional message to include with the resul.</param>
        public BaseResult(bool isSuccessful = true, bool isValid = true, string message = "")
            : this(isSuccessful, isValid)
        {
            this.Message = message;
        }
        #endregion

        #region "IResult"
        public bool IsSuccessful { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
        #endregion
    }
}
