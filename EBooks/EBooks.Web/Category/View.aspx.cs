using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Category
{
    public partial class View : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        private void BindData()
        {
            // do not show edin and delet buttons if user is not in admin role
            if (!UserModel.IsAdmin(Page.User.Identity.Name))
            {
                this.BooksByCategoryGridView.Columns[2].Visible = false;
                this.BooksByCategoryGridView.Columns[3].Visible = false;
            }

            string queryString = Request.QueryString["categoryId"];
            CategoryModel model = CategoryModelFactory.GetModel(queryString);

            this.CategoryName.Text = model.Name;

            var allBooksFromCategory = BookModelFactory.GetAllBooksByCategory(model.Id);
            this.BooksByCategoryGridView.DataSource = allBooksFromCategory;
            this.BooksByCategoryGridView.DataBind();
        }

        protected void BooksByCategoryGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.BooksByCategoryGridView.PageIndex = e.NewPageIndex;
            this.BindData();
        }
    }
}