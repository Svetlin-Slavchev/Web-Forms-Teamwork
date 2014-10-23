using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Web.UI;

namespace EBooks.Web.Category
{
    public partial class Delete : Page
    {
        protected void Page_Load()
        {
            if (!Page.IsPostBack)
            {
                string queryString = Request.QueryString["categoryId"];
                this.CategoryName.Text = CategoryModelFactory.GetModel(queryString).Name;
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int id;
            string queryString = Request.QueryString["categoryId"];
            int.TryParse(queryString, out id);

            CategoryModel model = new CategoryModel(id);
            if (model != null)
            {
                if (model.Delete())
                {
                    Response.Redirect("Index.aspx?successMessage=Category was successful deleted!");
                }

                else
                {
                    Response.Redirect("Index.aspx?errorMessage=Delete all books in category and try again!");
                }
                
            }
            else
            {
                Response.Redirect("Index.aspx?errorMessage=There is an error. That kind of categoty doesn't exist!");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}