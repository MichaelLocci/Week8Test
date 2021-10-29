using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.MVC.Models
{
    public class MenuViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Insert Name Menu")]
        [MaxLength(100, ErrorMessage = "Max lenght 100 characters")]
        [Display(Name = "Name Menu")]
        public string NameMenu { get; set; }
    }
}
