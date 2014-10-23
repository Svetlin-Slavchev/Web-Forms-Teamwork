using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Web.UI;

namespace EBooks.Web.Category
{
    public partial class Edit : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string queryString = Request.QueryString["categoryId"];
                this.CategoryName.Text = CategoryModelFactory.GetModel(queryString).Name;
            }
        }


        protected void EditButton_Click(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["categoryId"];
            CategoryModel model = CategoryModelFactory.GetModel(queryString);

            if (model != null)
            {
                model.Update(this.CategoryName.Text);
                Response.Redirect("Index.aspx?successMessage=Category updated!");
            }
            else
            {
                Response.Redirect("Index.aspx?errorMessage=Error. Category not updated!");
            }
        }
    }
}