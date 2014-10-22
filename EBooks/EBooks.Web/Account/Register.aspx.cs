using EBooks.Web.Factories;
using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI;

namespace EBooks.Web.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var userName = this.UserName.Text;

            // check if user name exist
            var existingUsers = UserModelFactory.GetAllUsers();
            if (existingUsers.FirstOrDefault(u => u.UserName == userName) != null)
            {
                this.ErrorMessage.Text = "Username is already exists!";
                return;
            }

            var password = this.Password.Text;
            var email = this.Email.Text;

            // create new user
            Membership.CreateUser(userName, password, email);

            // redirect to login page
            FormsAuthentication.RedirectFromLoginPage(userName, false);
        }
    }
}