using EBooks.Web.Models;
using System;
using System.Web.UI;

namespace EBooks.Web.Category
{
    public partial class Delete : Page
    {
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int id;
            string queryString = Request.QueryString["categoryId"];
            int.TryParse(queryString, out id);

            CategoryModel model = new CategoryModel(id);
            if (model != null)
            {
                model.Delete();
                Response.Redirect("Index.aspx?successMessage=Category is successful deleted!");
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