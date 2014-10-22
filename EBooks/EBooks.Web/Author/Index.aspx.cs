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
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<AuthorModel> authors = AuthorModelFactory.GetAll();

            this.AuthorsGridView.DataSource = authors;
            this.AuthorsGridView.DataBind();
        }
    }
}