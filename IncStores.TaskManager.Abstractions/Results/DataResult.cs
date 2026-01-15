namespace IncStores.TaskManager.Results
{
    public class DataResult<T> : BaseResult, IResult<T>
    {
        #region "Constructors"
        public DataResult() : base() { }
        public DataResult(bool isSuccessful = true, bool isValid = true)
            : base(isSuccessful, isValid) { }
        public DataResult(bool isSuccessful = true, bool isValid = true, string message = "")
            : base(isSuccessful, isValid, message) { }
        public DataResult(T resultData, bool isSuccessful = true, bool isValid = true)
            : base(isSuccessful, isValid)
        {
            this.ResultData = resultData;
        }
        public DataResult(T resultData, bool isSuccessful = true, bool isValid = true, string message = "")
            : base(isSuccessful, isValid, message)
        {
            this.ResultData = resultData;
        }
        #endregion

        #region "Public Properties"
        public T ResultData { get; set; }
        #endregion
    }
}
