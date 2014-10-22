﻿using EBooks.Web.Entities;
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
            if (!this.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (var db = new EBooksEntities())
            {
                try
                {
                    int selectedPublisher = int.Parse(Page.RouteData.Values["id"] as string);

                    var books = db.Books.Where(x => x.PublisherId == selectedPublisher)
                                        .Select(x => new { ID = x.Id, Title = x.Title, Description = x.Description });

                    this.BooksData.DataSource = books.ToList();
                    this.BooksData.DataBind();

                    this.SelectedPublisher = "Books of: " + db.Publishers.Single(x => x.Id == selectedPublisher).Name;
                }
                catch { }

                this.PublishersData.DataSource = db.Publishers.ToList();
                this.PublishersData.DataBind();
            }
        }

        protected void ShowDetails_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse((sender as LinkButton).CommandArgument);

            using (var db = new EBooksEntities())
            {
                var book = db.Books.Single(x => x.Id == bookId);

                this.AdditionalBookData.DataSource = new EBooks.Web.Entities.Book[] { book };
                this.AdditionalBookData.DataBind();
                this.AdditionalInfoHeader.Visible = true;
            }
        }
    }
}