﻿using Masterchef.Service;
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
            return View();
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
            return View();
        }

        // POST: CadastrarReceitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: CadastrarReceitaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
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