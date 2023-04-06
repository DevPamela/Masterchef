using MasterChef.Api.Models;
using MasterChef.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Masterchef.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly RecipeContext _recipeContext;

        public RecipeService(RecipeContext recipeContext)
        {
            _recipeContext = recipeContext;
        }

        public async Task AddRecipe(Recipe recipe)
        {
            await _recipeContext.Recipes.AddAsync(recipe);
            await _recipeContext.SaveChangesAsync();
        }

        public async Task UpdateRecipe(int id, Recipe recipe)
        {
            var recipeDatabase = await GetRecipe(id);

            recipeDatabase.Title = recipe.Title;
            recipeDatabase.Description = recipe.Description;
            recipeDatabase.Foto = recipe.Foto;
            recipeDatabase.Category = recipe.Category;
            recipeDatabase.Tags = recipe.Tags;
            recipeDatabase.Ingredients = recipe.Ingredients;
            recipeDatabase.PrepareModes = recipe.PrepareModes;

            await _recipeContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var recipe = _recipeContext.Recipes.FirstOrDefault(q => q.Id == id);
            _recipeContext.Recipes.Remove(recipe);
            await _recipeContext.SaveChangesAsync();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var result = await _recipeContext.Recipes
                .Include(q => q.Ingredients)
                .Include(q => q.PrepareModes)
                .Include(q => q.Category)
                .Include(q => q.Tags)
                .FirstOrDefaultAsync(q => q.Id == id);
            return result;
        }

        public async Task<List<Recipe>> GetAll()
        {
            return await _recipeContext.Recipes
                .Include(q => q.Ingredients)
                .Include(q => q.PrepareModes)
                .Include(q => q.Category)
                .Include(q => q.Tags)
                .ToListAsync();
        }
    }
}