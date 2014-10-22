using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Category
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CategoryModel> categories = CategoryModelFactory.GetAll();

            this.CategoriesGridView.DataSource = categories;
            this.CategoriesGridView.DataBind();
        }
    }
}