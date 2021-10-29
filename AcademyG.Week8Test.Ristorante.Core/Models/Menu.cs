using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.Core.Models
{
    public class Menu
    {

        public int Id { get; set; }
        public string NameMenu { get; set; }
        public List<Plate> Plates { get; set; }
    }
}
