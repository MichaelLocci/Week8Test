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
    public class PlatesController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public PlatesController(IMainBusinessLayer mainBusinessLayer)
        {
            mainBL = mainBusinessLayer;
        }

        public IActionResult Index(int id)
        {
            var result = mainBL.FetchPlates().Where(p => p.MenuId == id);
            var resultMapping = result.ToListViewModel();

            return View(resultMapping);
        }

        #region creazione prodotto

        [Authorize(Policy = "RestorerUser")]
        public IActionResult Create()
        {
            LoadViewBag();
            return View(new PlateViewModel());
        }

        //HTTP POST Products/Create
        [Authorize(Policy = "RestorerUser")]
        [HttpPost]
        public IActionResult Create(PlateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model == null)
            {
                return View("ExceptionError", new ResultBL(false, "Errore!"));
            }

            Plate newPlate = model.ToPlate();

            var result = mainBL.AddPlate(newPlate);
            if (!result.Success)
                return View("ExceptionError", result);

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region edit prodotto
        [Authorize(Policy = "RestorerUser")]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("NotFound");

            var plateToEdit = mainBL.GetPlateById(id);

            if (plateToEdit == null)
                return View("NotFound");

            var plateViewModel = plateToEdit.ToViewModel();
            LoadViewBag();
            return View(plateViewModel);
        }
        [Authorize(Policy = "RestorerUser")]
        [HttpPost]
        public IActionResult Edit(PlateViewModel pvm)
        {
            if (!ModelState.IsValid)
                return View(pvm);

            if (pvm == null)
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));

            var plateToEdit = pvm.ToPlate();
            var result = mainBL.EditPlate(plateToEdit);
            if (!result.Success)
            {
                return View("ExceptionError", new ResultBL(false, "Something wrong!"));
            }

            return View("Detail", pvm);
        }

        #endregion

        #region Cancellazione piatto ajax
        [Authorize(Policy = "RestorerUser")]
        [Route("Plates/DeleteAjax/{id}")]
        public IActionResult DeleteAjax(int id)
        {
            if (id <= 0)
                return Json(false);

            var result = mainBL.DeletePlate(id);

            return Json(result.Success);
        }

        #endregion

        private void LoadViewBag()
        {

            ViewBag.TypePlate = MappingExtension.FromEnumSelectList<TypePlate>();
            
        }
    }
}
