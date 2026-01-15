using IncStores.TaskManager.Results;
using System;
using System.Threading.Tasks;

namespace IncStores.TaskManager.Recipes
{
    public interface IRecipeTask
    {
        #region "Identification"
        /// <summary>
        /// Generated ID for the Recipe Task, used mainly for reporting and monitoring.
        /// </summary>
        Guid ID { get; set; }

        /// <summary>
        /// ID for the Recipe parent, used mainly for reporting and monitoring.
        /// </summary>
        int RecipeID { get; set; }

        /// <summary>
        /// Generated name used for reporing and monitoring (a concatenation of the
        /// parent Recipe ID and this Task's ID. This can be overriden to a custom name.
        /// </summary>
        string Name { get; }
        #endregion

        IServiceProvider ServiceProvider { get; set; }

        Task<IResult> ProcessAsync();
        Task<IResult> PreProcessAsync();
        Task<IResult> PostProcessAsync();
        Task<IResult> RunAsync();
    }

    public interface IRecipeTask<T> : IRecipeTask
    {
        /// <summary>
        /// Gets or Sets the Data used within the IRecipeTask.
        /// </summary>
        T Data { get; set; }
    }
}
