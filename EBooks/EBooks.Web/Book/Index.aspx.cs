using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Book
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
            //if (!UserModel.IsAdmin(Page.User.Identity.Name))
            //{
            //    this.BooksGridView.Columns[2].Visible = false;
            //    this.BooksGridView.Columns[3].Visible = false;
            //}

            List<BookModel> books = BookModelFactory.GetAll();

            this.BooksGridView.DataSource = books;
            this.BooksGridView.DataBind();
        }

        public void BooksGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.BooksGridView.PageIndex = e.NewPageIndex;
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