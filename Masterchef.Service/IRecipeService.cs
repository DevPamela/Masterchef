using MasterChef.Api.Models;

namespace Masterchef.Service
{
    public interface IRecipeService
    {
        Task UpdateRecipe(string title, string ingredients, string mododepreparo);

        Task Delete(string title);

        Task<Recipe> GetRecipe(int id);
        Task AddRecipe(Recipe recipe);

        Task<List<Recipe>> GetAll();
    }
}