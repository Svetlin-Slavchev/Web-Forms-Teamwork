using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Author
{
    public partial class Delete : System.Web.UI.Page
    {
        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            int id;
            string queryString = Request.QueryString["authorId"];
            int.TryParse(queryString, out id);

            AuthorModel model = new AuthorModel(id);
            if (model != null)
            {
                model.Delete();
                Response.Redirect("Index.aspx?successMessage=Author is successful deleted!");
            }
            else
            {
                Response.Redirect("Index.aspx?errorMessage=There is an error. This author doesn't exist!");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}