using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Author
{
    public partial class Create : System.Web.UI.Page
    {
        protected void CreateButton_Click(object sender, EventArgs e)
        {
            AuthorModel.Create(this.AuthorName.Text);

            Response.Redirect("Index.aspx?successMessage=Author created!");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}