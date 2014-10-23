using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Author
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PanelSuccess.Visible = false;
            this.PanelError.Visible = false;

            // show message from previos operations
            string successMessage = Request.QueryString["successMessage"];
            string errorMessage = Request.QueryString["errorMessage"];
            if (successMessage != null)
            {
                SuccessMessages(successMessage);
            }
            if (errorMessage != null)
            {
                ErrorMessages(errorMessage);
            }

            this.BindData();
        }

        private void BindData()
        {
            //do not show edin and delet buttons if user is not in admin role
            if (!UserModel.IsAdmin(Page.User.Identity.Name))
            {
                this.AuthorsGridView.Columns[2].Visible = false;
                this.AuthorsGridView.Columns[3].Visible = false;
                this.btnCreate.Visible = false;
            }

            List<AuthorModel> authors = AuthorModelFactory.GetAll(); 

            this.AuthorsGridView.DataSource = authors;
            this.AuthorsGridView.DataBind();
        }
        protected void AuthorsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.AuthorsGridView.PageIndex = e.NewPageIndex;
            this.BindData();
        }

        protected void SuccessMessages(string successMessage)
        {
            this.PanelSuccess.Visible = true;
            this.Success.Text = successMessage;
        }

        private void ErrorMessages(string errorMessage)
        {
            this.PanelError.Visible = true;
            this.Error.Text = errorMessage;
        }

       
    }
}