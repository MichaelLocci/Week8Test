using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.EF.Repositories
{
    public class PlateRepositoryEF : IPlateRepository
    {
        private readonly RestaurantContext ctx;
        public PlateRepositoryEF(RestaurantContext restaurantContext)
        {
            ctx = restaurantContext;
        }
        public bool AddItem(Plate item)
        {
            if (item == null)
                return false;

            ctx.Plates.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(Plate deleteItem)
        {
            if (deleteItem == null)
                return false;

            ctx.Plates.Remove(deleteItem);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Plate> Fetch(Func<Plate, bool> filter = null)
        {
            if (filter != null)
                return ctx.Plates.Where(filter);

            return ctx.Plates;
        }

        public Plate GetById(int id)
        {
            if (id <= 0)
                return null;

            return ctx.Plates.Find(id);
        }

        public Plate GetByName(string namePlate)
        {
            if (string.IsNullOrEmpty(namePlate))
                return null;

            return ctx.Plates.FirstOrDefault(p => p.NamePlate.Equals(namePlate));
        }

        public bool UpdateItem(Plate updateItem)
        {
            if (updateItem == null)
                return false;

            ctx.Entry(updateItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}
