using EBooks.Web.Models;
using System;
using System.Web.UI;

namespace EBooks.Web.Category
{
    public partial class Create : Page
    {
        protected void CreateButton_Click(object sender, EventArgs e)
        {
            CategoryModel.Create(this.CategoryName.Text);

            Response.Redirect("Index.aspx?successMessage=Category created!");
        }
    }
}