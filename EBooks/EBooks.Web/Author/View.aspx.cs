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
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["authorId"];
            AuthorModel model = AuthorModelFactory.GetModel(queryString);

            this.AuthorName.Text = model.Name;

            var allBooksFromAuthor = model.Books;
            this.BooksByAuthorGridView.DataSource = allBooksFromAuthor;
            this.BooksByAuthorGridView.DataBind();
        }
    }
}