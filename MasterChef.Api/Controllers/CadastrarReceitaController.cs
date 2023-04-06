using Masterchef.Service;
using MasterChef.Api.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

namespace MasterChef.Api.Controllers
{
    public class CadastrarReceitaController : Controller
    {
        private readonly IRecipeService _recipeService;

        public CadastrarReceitaController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        // GET: CadastrarReceitaController
        public ActionResult Index()
        {
            var recipt = new Recipe();
            return View(recipt);
        }

        // GET: CadastrarReceitaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CadastrarReceitaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CadastrarReceitaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Recipe receipe)
        {
            try
            {
                var invalid = _ValidateRecipe(receipe);

                if(invalid)
                {
                    return View(nameof(Index), receipe);
                }

                await _recipeService.AddRecipe(receipe);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Title", "Já existe uma receita com esse título.");
                return View(nameof(Index), receipe);
            }
        }

        // GET: CadastrarReceitaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var recipe = await _recipeService.GetRecipe(id);

            return View(nameof(Index), recipe);
        }

        // POST: CadastrarReceitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Recipe receipe)
        {
            try
            {
                await _recipeService.UpdateRecipe(id, receipe); 
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: CadastrarReceitaController/Delete/5
        public ActionResult Delete(int id)
        {
            _recipeService.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        // POST: CadastrarReceitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        private bool _ValidateRecipe(Recipe receipe)
        {
            if (receipe.Tags.Any(q => string.IsNullOrEmpty(q.Name)))
            {
                ModelState.AddModelError("Tags", "Tag não pode ser vazia");
                return true;
            }

            if (receipe.Ingredients.Count == 0)
            {
                ModelState.AddModelError("Ingredients", "Ingrediente não pode ser vazia");
                return true;
            }

            if (receipe.PrepareModes.Count == 0)
            {
                ModelState.AddModelError("PrepareModes", "Modo de preparo não pode ser vazia");
                return true;
            }

            return false;
        }
    }
    

}
