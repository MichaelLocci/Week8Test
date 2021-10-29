using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.Core.BusinessLayer
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IMenuRepository repoMenu;
        private readonly IPlateRepository repoPlate;
        private readonly IUserRepository repoUser;
        public MainBusinessLayer(IMenuRepository menuRepository, IPlateRepository plateRepository, IUserRepository userRepository)
        {
            repoMenu = menuRepository;
            repoPlate = plateRepository;
            repoUser = userRepository;
        }

        #region Menu

        public ResultBL AddMenu(Menu menu)
        {
            if (menu == null)
                return new ResultBL(false, "Invalid Menu Data");

            var result = repoMenu.AddItem(menu);
            return new ResultBL(result, result ? "OK!" : "Cannot add menu");
        }

        public IEnumerable<Menu> FetchMenu(Func<Menu, bool> filter = null)
        {
            return repoMenu.Fetch(filter);
        }
        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;
            return repoMenu.GetById(id);
        }

        public Menu GetMenuByName(string nameMenu)
        {
            if (string.IsNullOrEmpty(nameMenu))
                return null;

            return repoMenu.GetByName(nameMenu);
        }
        #endregion

        #region Plate
        public ResultBL AddPlate(Plate newPlate)
        {
            if (newPlate == null)
                return new ResultBL(false, "Inavalid Data Plate");

            var result = repoPlate.AddItem(newPlate);
            return new ResultBL(result, result ? "OK!" : "Cannot add plate");
        }

        public ResultBL DeletePlate(int idPlate)
        {
            if (idPlate <= 0)
                return new ResultBL(false, "Invalid Id Plate");

            var deletePlate = repoPlate.GetById(idPlate);

            var result = repoPlate.DeleteItem(deletePlate);
            return new ResultBL(result, result ? "OK!" : "Cannot delete plate");
        }

        public ResultBL EditPlate(Plate modifyPlate)
        {
            if (modifyPlate == null)
                return new ResultBL(false, "Invalid Plate Data");

            var result = repoPlate.UpdateItem(modifyPlate);

            return new ResultBL(result, result ? "OK!" : "Cannot update plate");
        }

        public IEnumerable<Plate> FetchPlates(Func<Plate, bool> filter = null)
        {
            return repoPlate.Fetch(filter);
        }

        public Plate GetPlateById(int id)
        {
            if (id <= 0)
                return null;

            return repoPlate.GetById(id);
        }

        public Plate GetPlateByName(string namePlate)
        {
            if (string.IsNullOrEmpty(namePlate))
                return null;

            return repoPlate.GetByName(namePlate);
        }
        #endregion

        #region User

        public User GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return repoUser.GetByEmail(email);
        }

        public ResultBL CreateUser(User user)
        {
            if (user == null)
                return new ResultBL(false, "Invalid User");

            var result = repoUser.AddItem(user);

            return new ResultBL(result, result ? "Ok!" : "Sorry, something wrong");
        }

        #endregion
    }
}
