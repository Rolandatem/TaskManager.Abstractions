using IncStores.TaskManager.Results;
using System.Threading.Tasks;

namespace IncStores.TaskManager.Recipes
{
    public interface IRecipe
    {
        #region "Identification"
        int ID { get; set; }
        string Name { get; }
        #endregion

        string Data { get; set; }
        Task<IResult> ProcessAsync();
        Task<IResult> PreProcessAsync();
        Task<IResult> PostProcessAsync();
        Task<IResult> RunAsync();
    }
}
