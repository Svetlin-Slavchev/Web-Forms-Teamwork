using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Author
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string queryString = Request.QueryString["authorId"];
                this.AuthorName.Text = AuthorModelFactory.GetModel(queryString).Name;
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["categoryId"];
            AuthorModel model = AuthorModelFactory.GetModel(queryString);

            if (model != null)
            {
                model.Update(this.AuthorName.Text);
                Response.Redirect("Index.aspx?successMessage=Author updated!");
            }
            else
            {
                Response.Redirect("Index.aspx?errorMessage=Error!Author was not updated!");
            }
        }
    }
}