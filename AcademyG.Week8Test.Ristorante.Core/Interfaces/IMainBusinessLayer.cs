using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.Core.Interfaces
{
    public interface IMainBusinessLayer
    {

        #region Menu

        IEnumerable<Menu> FetchMenu(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        Menu GetMenuByName(string nameMenu);
        ResultBL AddMenu(Menu menu);

        #endregion

        #region Piatti

        IEnumerable<Plate> FetchPlates(Func<Plate, bool> filter = null);
        Plate GetPlateById(int id);
        Plate GetPlateByName(string namePlate);
        ResultBL AddPlate(Plate newPlate);
        ResultBL EditPlate(Plate modifyPlate);
        ResultBL DeletePlate(int idPlate);

        #endregion

        #region User

        User GetUserByEmail(string email);
        ResultBL CreateUser(User user);

        #endregion
    }
}
