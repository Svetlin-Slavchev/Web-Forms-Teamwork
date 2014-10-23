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
    public partial class Edit : System.Web.UI.Page
    {
        private EBooksEntities db = new EBooksEntities();
        private Entities.Author oldAuthor;

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

        public void EditBook_Click(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["bookId"];
            BookModel model = BookModelFactory.GetModel(queryString);

            if (model != null)
            {
                var existingBook = this.db.Books.FirstOrDefault(b => b.Id == model.Id);
                existingBook.Title = this.BookTitle.Text;
                existingBook.SubTitle = this.SubTitle.Text;
                var oldAuthor = existingBook.Authors.ToList()[0];
                var authorName = this.Author.Text;
                var author = db.Authors.FirstOrDefault(a => a.Name == authorName);
                if (author == null)
                {
                    author = new Entities.Author(authorName);
                    this.db.Authors.Add(author);
                }
                var publisherName = this.Publisher.Text;
                var publisher = db.Publishers.FirstOrDefault(p => p.Name == publisherName);
                if (publisher == null)
                {
                    publisher = new Entities.Publisher(publisherName);
                    this.db.Publishers.Add(publisher);
                }
                existingBook.Authors.Clear();
                existingBook.Authors.Add(author);
                existingBook.Publisher = publisher;
                existingBook.ISBN = this.ISBN.Text;
                existingBook.Description = this.Description.Text;
                var pages = 0;
                if (int.TryParse(this.Pages.Text, out pages))
                {
                    existingBook.Pages = pages;
                }

                var date = new DateTime();
                if (DateTime.TryParse(this.Year.Text, out date))
                {
                    existingBook.Year = date;
                }

                var categoryName = this.CategoryDropDown.SelectedValue;
                var category = db.Categories.FirstOrDefault(c => c.Name == categoryName);
                existingBook.CategoryId = category.Id;
                if ((this.Picture.PostedFile != null) && (this.Picture.PostedFile.ContentLength > 0))
                {
                    string fileName = System.IO.Path.GetFileName(this.Picture.PostedFile.FileName);
                    string saveLocation = Server.MapPath("Pictures") + "\\" + fileName;
                    try
                    {
                        this.Picture.PostedFile.SaveAs(saveLocation);
                        existingBook.ImageURL = "Pictures" + "\\" + fileName;
                        //Response.Write("The file has been uploaded.");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                        //Note: Exception.Message returns detailed message that describes the current exception. 
                        //For security reasons, we do not recommend you return Exception.Message to end users in 
                        //production environments. It would be better just to put a generic error message. 
                    }
                }
                oldAuthor.Books.Remove(existingBook);
                author.Books.Add(existingBook);
                this.db.SaveChanges();
                Response.Redirect("Index.aspx?successMessage=Book updated!");
            }
            else
            {
                Response.Redirect("Index.aspx?errorMessage=Error. Book not updated!");
            }

        }


    }
}