using IncStores.TaskManager.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IncStores.TaskManager.Recipes
{
    public abstract class BaseRecipe : IRecipe
    {
        #region "Member Variables"
        readonly IServiceProvider _serviceProvider = null;
        #endregion

        #region "Constructor"
        public BaseRecipe(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        #endregion

        #region "Private Methods"
        private Task<IRecipeTask> CommonTaskGeneratorAsync<C>(IRecipeTask task, IServiceProvider serviceProvider)
        {
            if (task == null) { throw new Exception($"No Recipe Tasks were found of type {typeof(C).Name}."); }

            task.ServiceProvider = serviceProvider;
            task.RecipeID = this.ID;

            return Task.FromResult(task);
        }
        #endregion

        #region "Public Methods"
        public async Task<IRecipeTask> GetRecipeTaskAsync<C>()
        {
            IRecipeTask task = (IRecipeTask)_serviceProvider.GetServices<IRecipeTask>().OfType<C>().FirstOrDefault();
            return await CommonTaskGeneratorAsync<C>(task, _serviceProvider);
        }
        public async Task<IRecipeTask> GetRecipeTaskInScopeAsync<C>(IServiceScope scope)
        {
            IRecipeTask task = (IRecipeTask)scope.ServiceProvider.GetServices<IRecipeTask>().OfType<C>().FirstOrDefault();
            return await CommonTaskGeneratorAsync<C>(task, scope.ServiceProvider);
        }
        #endregion

        #region "IRecipe"
        public int ID { get; set; }
        public virtual string Name => this.ID.ToString();
        public string Data { get; set; }
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
}
