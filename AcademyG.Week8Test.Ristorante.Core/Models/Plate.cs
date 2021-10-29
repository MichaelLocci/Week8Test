using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.Core.Models
{
    public enum TypePlate
    {
        First,
        Second,
        Side,
        Dessert
    }
    public class Plate
    {

        public int Id { get; set; }
        public string NamePlate { get; set; }
        public string Description { get; set; }
        public TypePlate TypePlate { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
