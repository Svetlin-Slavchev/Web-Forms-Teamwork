using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        public void BooksGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.BooksGridView.PageIndex = e.NewPageIndex;
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
    }
}