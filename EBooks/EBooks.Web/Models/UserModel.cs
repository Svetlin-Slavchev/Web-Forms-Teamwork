using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace EBooks.Web.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string LoweredUserName { get; set; }

        public static bool IsAdmin(string userName)
        {
            if (Roles.IsUserInRole(userName, "admin"))
            {
                return true;
            }

            return false;
        }
    }
}