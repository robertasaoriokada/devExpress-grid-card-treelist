using DXWebApplication1.Models.DbAp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DXWebApplication1.Models.Services
{
    public static class UsersService
    {
        private static DXWebApplication1.Models.DbAp.Model1 db = new Model1();
        public static List<user> GetUsers()
        {
            var model = db.users.ToList();
            if (model == null)
            {
                throw new Exception("Algo deu errado");
            }
            return model;
        }

        public static void AddUsers(user newUser)
        {
            if(!(newUser is user))
            {
                throw new Exception();
            }

            db.users.Add(newUser);
            db.SaveChanges();
        }

        public static void UpdateUsers(user updatedUser)
        {
            if (!(updatedUser is user))
            {
                throw new Exception();
            }

            var model = db.users.ToList();
            var modelItem = db.users.FirstOrDefault(x => x.userId == updatedUser.userId);
            if (modelItem != null)
            {
                modelItem.role = updatedUser.role;
                modelItem.name = updatedUser.name;
                modelItem.age = updatedUser.age;
                modelItem.bio = updatedUser.bio;
                modelItem.createdAt = updatedUser.createdAt;
                db.SaveChanges();
            }
        }

        public static void DeleteUsers(int id)
        {
            var model = db.users.ToList();
            var modelItem = db.users.FirstOrDefault(x => x.userId == id);
            if(modelItem != null)
            {

                db.users.Remove(modelItem);
                db.SaveChanges();
            } else
            {
                throw new Exception("User não encontrado");
            }
        }
    }
}