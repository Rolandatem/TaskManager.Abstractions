using IncStores.TaskManager.Results;
using System;
using System.Threading.Tasks;

namespace IncStores.TaskManager.Recipes
{
    public abstract class BaseRecipeTask : IRecipeTask
    {
        #region "Constructor"
        public BaseRecipeTask() { this.ID = Guid.NewGuid(); }
        #endregion

        #region "IRecipeTask"

        #region "Identification"
        public Guid ID { get; set; }
        public int RecipeID { get; set; }
        public virtual string Name { get; } = String.Empty;
        #endregion

        public IServiceProvider ServiceProvider { get; set; }

        public virtual async Task<IResult> PreProcessAsync() => await Task.FromResult(new BasicResult());
        public virtual async Task<IResult> PostProcessAsync() => await Task.FromResult(new BasicResult());
        public abstract Task<IResult> ProcessAsync();
        public virtual async Task<IResult> RunAsync()
        {
            IResult success = await PreProcessAsync();
            if (success.IsSuccessful && success.IsValid) { success = await ProcessAsync(); }
            if (success.IsSuccessful && success.IsValid) { success = await PostProcessAsync(); }

            return success;
        }
        #endregion
    }

    public abstract class BaseRecipeTask<T> : BaseRecipeTask, IRecipeTask<T>
    {
        #region "Constructor"
        public BaseRecipeTask() : base() { }
        #endregion

        #region "IRecipeTask<T>"
        public T Data { get; set; }
        #endregion
    }
}
