using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EBooks.Web.Entities;
using EBooks.Web.Factories;

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
            }
        }

        public void CreateBook_Click(object sender, EventArgs e)
        {
            var newBook = new Entities.Book();
            newBook.Title = this.BookTitle.Text;
            newBook.SubTitle = this.SubTitle.Text;
            var author = new Entities.Author();
            author.Name = this.Author.Text;
            var publisher = new Entities.Publisher();
            publisher.Name = this.Publisher.Text;
            newBook.Authors.Add(author);
            newBook.Publisher = publisher;
            newBook.ISBN = this.ISBN.Text;
            newBook.Description = this.Description.Text;
            newBook.Pages = int.Parse(this.Pages.Text);
            newBook.Year = DateTime.Parse(this.Year.Text);
            var categoryName = this.CategoryDropDown.SelectedValue;
            var category = db.Categories.FirstOrDefault(c => c.Name == categoryName); 
            newBook.CategoryId = category.Id;
            if ((this.Picture.PostedFile != null) && (this.Picture.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(this.Picture.PostedFile.FileName);
                string saveLocation = Server.MapPath("Pictures") + "\\" + fn;
                try
                {
                    this.Picture.PostedFile.SaveAs(saveLocation);
                    newBook.ImageURL = "Pictures" + "\\" + fn;
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
            this.db.Publishers.Add(publisher);
            this.db.Authors.Add(author);
            this.db.Books.Add(newBook);
            this.db.SaveChanges();
        }
    }
}