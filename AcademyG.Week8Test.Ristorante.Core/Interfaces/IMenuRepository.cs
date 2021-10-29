using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.Core.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        public Menu GetByName(string nameMenu);
    }
}
