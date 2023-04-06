using MasterChef.Api.Models;

namespace Masterchef.Service
{
    public interface IRecipeService
    {
        Task UpdateRecipe(string title, string ingredients, string mododepreparo);

        Task Delete(int id);

        Task<Recipe> GetRecipe(int id);
        Task AddRecipe(Recipe recipe);

        Task<List<Recipe>> GetAll();
    }
}