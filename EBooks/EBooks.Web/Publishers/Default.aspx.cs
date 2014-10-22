using EBooks.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Publishers
{
    public partial class Default : System.Web.UI.Page
    {
        public string SelectedPublisher { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new EBooksEntities())
            {
                try
                {
                    int selectedPublisher = int.Parse(Request["id"]);
                    var books = db.Books.Where(x => x.PublisherId == selectedPublisher);
                    this.BooksData.DataSource = books.ToList();
                    this.BooksData.DataBind();

                    this.SelectedPublisher = "Books of: " + db.Publishers.Single(x => x.Id == selectedPublisher).Name;
                }
                catch { }

                this.PublishersData.DataSource = db.Publishers.ToList();
                this.PublishersData.DataBind();
            }
        }
    }
}