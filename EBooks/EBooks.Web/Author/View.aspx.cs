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
            this.BindData();
        }

        private void BindData()
        {
            // do not show edit and delete buttons if user is not in admin role
            if (!UserModel.IsAdmin(Page.User.Identity.Name))
            {
                this.BooksByAuthorGridView.Columns[2].Visible = false;
                this.BooksByAuthorGridView.Columns[3].Visible = false;
            }

            string queryString = Request.QueryString["authorId"];
            AuthorModel model = AuthorModelFactory.GetModel(queryString);
            
            this.AuthorName.Text = model.Name;

            var allBooksFromAuthor = BookModelFactory.GetAllBooksByAuthorId(model.Id);

            if (allBooksFromAuthor.Count != 0)
            {
                this.BooksByAuthorGridView.DataSource = allBooksFromAuthor;
            }
            else
            {
                this.BooksByAuthorGridView.DataSource = new List<BookModel>() { 
                    new BookModel(){ 
                        Title = "No books from this author..."
                    }
                };
            }
            this.BooksByAuthorGridView.DataBind();
        }

        protected void BooksByAuthorGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.BooksByAuthorGridView.PageIndex = e.NewPageIndex;
            this.BindData();
        }
    }
}