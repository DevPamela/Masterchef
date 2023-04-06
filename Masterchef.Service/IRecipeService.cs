using MasterChef.Api.Models;

namespace Masterchef.Service
{
    public interface IRecipeService
    {
        Task UpdateRecipe(int id, Recipe recipe);

        Task Delete(int id);

        Task<Recipe> GetRecipe(int id);
        Task AddRecipe(Recipe recipe);

        Task<List<Recipe>> GetAll();
    }
}