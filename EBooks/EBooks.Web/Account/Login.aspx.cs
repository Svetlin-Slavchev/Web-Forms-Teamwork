using System;
using System.Web.Security;
using System.Web.UI;

namespace EBooks.Web.Account
{
    public partial class Login : Page
    {
        protected void LogIn(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(UserName.Text, Password.Text))
            {
                FormsAuthentication.SetAuthCookie(this.UserName.Text,
                    this.RememberMe.Checked == true ? true : false);

                string returnUrl = Request.QueryString["ReturnUrl"];
                if (returnUrl == null)
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    Response.Redirect(returnUrl);
                }
            }
            else
            {
                this.FailureText.Text = "Incorrect username or password!";
                this.ErrorMessage.Visible = true;
            }
        }
    }
}