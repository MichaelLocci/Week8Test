using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.MVC.Models
{
    public class PlateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Insert Name Plate!")]
        [MaxLength(50, ErrorMessage = "Max lenght 50 characters")]
        [Display(Name = "Name Plate")]
        public string NamePlate { get; set; }
        [Required(ErrorMessage = "Insert description!")]
        [MaxLength(200, ErrorMessage = "Max lenght 200 characters")]
        [Display(Name = "Description Plate")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Choose Type Plate")]
        [Display(Name = "Type plate")]
        public TypePlate TypePlate { get; set; }
        [Required(ErrorMessage = "Insert Price!")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        public int MenuId { get; set; }
    }
}
