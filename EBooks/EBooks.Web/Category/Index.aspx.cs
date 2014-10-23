using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Category
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.PanelSuccess.Visible = false;
            this.PanelError.Visible = false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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
            // do not show edin and delet buttons if user is not in admin role
            if (!UserModel.IsAdmin(Page.User.Identity.Name))
            {
                this.CategoriesGridView.Columns[2].Visible = false;
                this.CategoriesGridView.Columns[3].Visible = false;
            }

            List<CategoryModel> categories = CategoryModelFactory.GetAll();

            this.CategoriesGridView.DataSource = categories;
            this.CategoriesGridView.DataBind();
        }

        protected void CategoriesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.CategoriesGridView.PageIndex = e.NewPageIndex;
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