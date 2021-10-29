using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.EF.Repositories
{
    public class MenuRepositoryEF : IMenuRepository
    {
        private readonly RestaurantContext ctx;
        public MenuRepositoryEF(RestaurantContext restaurantContext)
        {
            ctx = restaurantContext;
        }
        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;

            ctx.Menus.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(Menu deleteItem)
        {
            if (deleteItem == null)
                return false;

            ctx.Menus.Remove(deleteItem);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {

            if (filter != null)
                return ctx.Menus.Where(filter);
            return ctx.Menus;
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Menus.Find(id);
        }

        public Menu GetByName(string nameMenu)
        {
            if (string.IsNullOrEmpty(nameMenu))
                return null;

            return ctx.Menus.FirstOrDefault(m => m.NameMenu.Equals(nameMenu));
        }

        public bool UpdateItem(Menu updateItem)
        {
            if (updateItem == null)
                return false;

            ctx.Entry(updateItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
