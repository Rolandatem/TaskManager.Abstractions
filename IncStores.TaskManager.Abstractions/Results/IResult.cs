namespace IncStores.TaskManager.Results
{
    public interface IResult
    {
        /// <summary>
        /// Identifies if an operation was successful in PROCESSING its logic.
        /// </summary>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Identifies if an operation is valid based on its OPTIMISTIC logic.
        /// </summary>
        bool IsValid { get; set; }

        string Message { get; set; }
    }

    /// <summary>
    /// An extension to the <see cref="IResult"/> interface that also returns
    /// data with the sucessful/valid result.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResult<T> : IResult
    {
        /// <summary>
        /// The data to return in the result.
        /// </summary>
        T ResultData { get; set; }
    }
}
