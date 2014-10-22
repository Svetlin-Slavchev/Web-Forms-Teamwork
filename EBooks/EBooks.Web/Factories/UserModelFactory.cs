using EBooks.Web.Entities;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBooks.Web.Factories
{
    public class UserModelFactory
    {
        private static EBooksEntities db = new EBooksEntities();

        public static List<UserModel> GetAllUsers()
        {
            var users = db.aspnet_Users
                    .Select(x => new UserModel
                    {
                        UserName = x.UserName,
                    })
                    .ToList();

            return users;
        }
    }
}