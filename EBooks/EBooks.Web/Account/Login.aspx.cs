using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using EBooks.Web.Models;
using System.Web.Security;
using System.Security.Principal;

namespace EBooks.Web.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(UserName.Text, Password.Text))
            {
                HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(UserName.Text), null);
                this.ErrorMessage.Visible = true;
                this.FailureText.Text = Page.User.Identity.IsAuthenticated.ToString();
            }
            else
            {
                this.FailureText.Text = "Incorrect username or password";
                this.ErrorMessage.Visible = true;
            }
        }
    }
}