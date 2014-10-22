using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EBooks.Web.Models;
using System.Web.Security;
using EBooks.Web.Factories;

namespace EBooks.Web.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var userName = this.UserName.Text;
            var existingUsers = UserModelFactory.GetAllUsers();
            if (existingUsers.FirstOrDefault(u => u.UserName == userName) != null)
            {
                this.ErrorMessage.Text = "Username is already exists!";
                return;
            }
            var password = this.Password.Text;
            var confirmPassword = this.ConfirmPassword.Text;
            if (password!=confirmPassword)
            {
                this.ErrorMessage.Text = "Passwords do not match!";
                return;
            }
            var email=this.Email.Text;
            Membership.CreateUser(userName, password, email);
        }
    }
}