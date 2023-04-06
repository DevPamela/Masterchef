using Masterchef.Service;
using MasterChef.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
                if (receipe.Tags.Any(q => string.IsNullOrEmpty(q.Name)))
                {
                    ModelState.AddModelError("Tags", "Tag não pode ser vazia");
                    return View(nameof(Index), receipe);
                }

                if (receipe.Ingredients.Count == 0)
                {
                    ModelState.AddModelError("Ingredients", "Ingrediente não pode ser vazia");
                    return View(nameof(Index), receipe);
                }

                if (receipe.PrepareModes.Count == 0)
                {
                    ModelState.AddModelError("PrepareModes", "Modo de preparo não pode ser vazia");
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
        public ActionResult Edit(int id)
        {
            return RedirectToAction("Index", "Home");
        }

        // POST: CadastrarReceitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
    }
}
