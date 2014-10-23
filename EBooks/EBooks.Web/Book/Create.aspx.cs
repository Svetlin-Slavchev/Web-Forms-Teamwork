using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EBooks.Web.Entities;
using EBooks.Web.Factories;
using System.IO;

namespace EBooks.Web.Book
{
    public partial class Create : System.Web.UI.Page
    {
        private EBooksEntities db = new EBooksEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var categories = CategoryModelFactory.GetAll();
                this.CategoryDropDown.DataSource = categories;
                this.CategoryDropDown.DataBind();

                this.Author.DataSource = AuthorModelFactory.GetAll().Select(x => x.Name);
                this.Author.DataBind();

                this.Publisher.DataSource = PublisherModelFactory.GetAll().Select(x=>x.Name);
                this.Publisher.DataBind();
            }
        }

        public void CreateBook_Click(object sender, EventArgs e)
        {
            var newBook = new Entities.Book();
            newBook.Title = this.BookTitle.Text;
            newBook.SubTitle = this.SubTitle.Text;
            var authorName = this.Author.Text;
            var author = db.Authors.FirstOrDefault(a => a.Name == authorName);
            if (author==null)
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

            newBook.Authors.Add(author);
            newBook.Publisher = publisher;
            newBook.ISBN = this.ISBN.Text;
            newBook.Description = this.Description.Text;
            var pages = 0;
            if (int.TryParse(this.Pages.Text,out pages))
            {
                newBook.Pages = pages;
            }

            var date = new DateTime();
            if (DateTime.TryParse(this.Year.Text,out date))
            {
                newBook.Year = date;
            }
            
            var categoryName = this.CategoryDropDown.SelectedValue;
            var category = db.Categories.FirstOrDefault(c => c.Name == categoryName); 
            newBook.CategoryId = category.Id;
            if ((this.Content.PostedFile != null) && (this.Content.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(this.Content.PostedFile.FileName);
                if (!Directory.Exists(Server.MapPath("BooksContent")))
                {
                    Directory.CreateDirectory(Server.MapPath("BooksContent"));
                }
                string saveLocation = Server.MapPath("BooksContent") + "\\" + fileName;
                try
                {
                    this.Content.PostedFile.SaveAs(saveLocation);
                    newBook.DownloadURL = "BooksContent" + "\\" + fileName;
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
            if ((this.Picture.PostedFile != null) && (this.Picture.PostedFile.ContentLength > 0))
            {
                string fileName = System.IO.Path.GetFileName(this.Picture.PostedFile.FileName);
                string saveLocation = Server.MapPath("Pictures") + "\\" + fileName;
                try
                {
                    this.Picture.PostedFile.SaveAs(saveLocation);
                    newBook.ImageURL = "Pictures" + "\\" + fileName;
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
            author.Books.Add(newBook);
            this.db.Books.Add(newBook);
            this.db.SaveChanges();
            Response.Redirect("Index.aspx?successMessage=Book was created!");
        }
    }
}