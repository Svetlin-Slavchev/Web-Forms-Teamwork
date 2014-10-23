using EBooks.Web.Entities;
using EBooks.Web.Factories;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Book
{
    public partial class Delete : System.Web.UI.Page
    {
        private EBooksEntities db = new EBooksEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string queryString = Request.QueryString["bookId"];
                BookModel model = BookModelFactory.GetModel(queryString);
                var existingBook = this.db.Books.FirstOrDefault(b => b.Id == model.Id);
                this.BookTitle.Text = existingBook.Title;
                this.SubTitle.Text = existingBook.SubTitle;
                this.Author.Text = existingBook.Authors.ToList()[0].Name;
                var publisher = db.Publishers.FirstOrDefault(p => p.Id == model.PublisherId);
                this.Publisher.Text = publisher.Name;
                this.ISBN.Text = model.ISBN;
                this.Description.Text = model.Description;
                this.Pages.Text = model.Pages.ToString();
                this.Year.Text = model.Year == null ? "" : model.Year.Value.ToString("mm/dd/yyyy");
                var category = db.Categories.FirstOrDefault(c => c.Id == model.CategoryId);
                var categories = CategoryModelFactory.GetAll();
                this.CategoryDropDown.DataSource = categories;
                this.CategoryDropDown.DataBind();
                this.CategoryDropDown.SelectedValue = category.Name;
            }
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        public void DeleteButton_Click(object sender, EventArgs e)
        {
            int bookId;
            string queryString = Request.QueryString["bookId"];
            int.TryParse(queryString, out bookId);

            var existingBook = this.db.Books.FirstOrDefault(b => b.Id == bookId);

            if (existingBook != null)
            {
                var category = this.db.Categories.FirstOrDefault(c => c.Id == existingBook.CategoryId);
                category.Books.Remove(existingBook);
                var authors = this.db.Authors.Where(a => a.Books.Any(b=>b.Id==existingBook.Id));

                foreach (var author in authors.ToList())
                {
                    author.Books.Remove(existingBook);
                }
                this.db.Books.Remove(existingBook);
                this.db.SaveChanges();
                Response.Redirect("Index.aspx?successMessage=Book was successful deleted!");
            }
            else
            {
                Response.Redirect("Index.aspx?errorMessage=There is an error. That book doesn't exist!");
            }
        }
    }
}