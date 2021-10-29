using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.Core.Models;
using AcademyG.Week8Test.Ristorante.MVC.Helpers;
using AcademyG.Week8Test.Ristorante.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public MenuController(IMainBusinessLayer mainBusinessLayer)
        {
            mainBL = mainBusinessLayer;
        }
        public IActionResult Index()
        {
            var result = mainBL.FetchMenu();
            var resultMapping = result.ToListViewModel();
            return View(resultMapping);
        }

        public IActionResult Detail(int id)
        {
            if (id <= 0)
                return View("NotFound");

            var menu = mainBL.GetMenuById(id);

            if (menu == null)
                return View("NotFound");

            var resultMapped = menu.ToViewModel();

            return View(resultMapped);
        }

        #region creazione menu

        [Authorize(Policy = "RestorerUser")]
        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }

        //HTTP POST Products/Create
        [Authorize(Policy = "RestorerUser")]
        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Errore!"));
            }

            Menu newMenu = model.ToMenu();

            var result = mainBL.AddMenu(newMenu);
            if (!result.Success)
                return View("ExceptionError", result);

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
