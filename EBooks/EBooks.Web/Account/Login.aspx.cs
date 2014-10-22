using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EBooks.Web.Models;
using System.Web.Security;

namespace EBooks.Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(this.UserName.Text, this.Password.Text))
            {
                if (this.RememberMe.Checked)
                {
                    FormsAuthentication.RedirectFromLoginPage(this.UserName.Text, true);
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(this.UserName.Text, false);
                }
            }
            else
            {
                this.FailureText.Text= "Login Error";
            }
        }
    }
}