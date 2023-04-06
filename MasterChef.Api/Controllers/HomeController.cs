using Masterchef.Domain;
using Masterchef.Service;
using MasterChef.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace MasterChef.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public HomeController( IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await _recipeService.GetAll();
            
            return View(recipes);

        }
        
        [HttpGet("/receitas")]
        public async Task<IActionResult> Get()
        {

            var receitas = await _recipeService.GetAll();
            
            return Json(receitas);
        }
        
        [HttpPost("Post")]
        public async Task<IActionResult> Post(Recipe recipe)
        {
            try
            {
                await _recipeService.AddRecipe(recipe);

                return Ok(recipe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}