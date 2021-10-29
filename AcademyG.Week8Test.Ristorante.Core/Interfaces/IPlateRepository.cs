using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.Core.Interfaces
{
    public interface IPlateRepository : IRepository<Plate>
    {
        public Plate GetByName(string namePlate);
    }
}
