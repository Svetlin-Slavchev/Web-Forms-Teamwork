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
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = Request.QueryString["bookId"];
            BookModel model = BookModelFactory.GetBookById(Int32.Parse(queryString)); //AuthorModelFactory.GetModel(queryString);

            this.BookTitle.InnerText = model.Title;
            this.BookSubTitle.InnerText = "Sub Title: " + model.SubTitle;

            this.BookImage.ImageUrl = model.ImageURL;

            this.ISBNContainer.InnerText = "ISBN: " + model.ISBN;
            this.PagesContainer.InnerText = "Pages: " + model.Pages.ToString();
            this.YearContainer.InnerText = string.Format("Year: {0}", model.Year == null ? "" : model.Year.Value.Year.ToString());
            this.DescriptionContainer.InnerText = "Description: " + model.Description;

            this.DownloadLink.NavigateUrl = model.DownloadURL;
            this.DownloadLink.Text = "DOWNLOAD";

            this.DataBind();
        }
    }
}