using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.EF.Repositories
{
    public class UserRepositoryEF : IUserRepository
    {
        private readonly RestaurantContext ctx;

        public UserRepositoryEF(RestaurantContext restaurantContext)
        {
            ctx = restaurantContext;
        }
        public bool AddItem(User item)
        {
            if (item == null)
                return false;

            ctx.Users.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItem(User deleteItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Fetch(Func<User, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            return ctx.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(User updateItem)
        {
            throw new NotImplementedException();
        }
    }
}
