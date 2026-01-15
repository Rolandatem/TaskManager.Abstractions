namespace IncStores.TaskManager.Results
{
    public class BasicResult : BaseResult
    {
        #region "Constructors"
        public BasicResult() : base() { }
        public BasicResult(bool isSuccessful = true, bool isValid = true)
            : base(isSuccessful, isValid) { }
        public BasicResult(bool isSuccessful = true, bool isValid = true, string message = "")
            : base(isSuccessful, isValid, message) { }
        #endregion
    }
}
