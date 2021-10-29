using AcademyG.Week8Test.Ristorante.Core.Models;
using AcademyG.Week8Test.Ristorante.MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.MVC.Helpers
{
    public static class MappingExtension
    {
        public static IEnumerable<SelectListItem> FromEnumSelectList<T>() where T : struct
        {
            return (Enum.GetValues(typeof(T))).Cast<T>().Select(
                e => new SelectListItem() { Text = e.ToString(), Value = e.ToString() }).ToList();
        }

        #region Menu
        public static MenuViewModel ToViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                NameMenu = menu.NameMenu
            };
        }

        public static IEnumerable<MenuViewModel> ToListViewModel(this IEnumerable<Menu> menus)
        {
            return menus.Select(e => e.ToViewModel());
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                NameMenu = menuViewModel.NameMenu
            };
        }
        #endregion

        #region Plate

        public static PlateViewModel ToViewModel(this Plate plate)
        {
            return new PlateViewModel
            {
                Id = plate.Id,
                NamePlate = plate.NamePlate,
                Description = plate.Description,
                TypePlate = plate.TypePlate,
                Price = plate.Price,
                MenuId =plate.MenuId
            };
        }

        public static IEnumerable<PlateViewModel> ToListViewModel(this IEnumerable<Plate> plates)
        {
            return plates.Select(e => e.ToViewModel());
        }

        public static Plate ToPlate(this PlateViewModel plateViewModel)
        {
            return new Plate
            {
                Id = plateViewModel.Id,
                NamePlate = plateViewModel.NamePlate,
                Description = plateViewModel.Description,
                TypePlate = plateViewModel.TypePlate,
                Price = plateViewModel.Price,
                MenuId = plateViewModel.MenuId
            };
        }

        #endregion
    }
}
