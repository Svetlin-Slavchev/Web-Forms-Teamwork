using EBooks.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EBooks.Web.Models
{
    public class BookModel
    {
        private static EBooksEntities db = new EBooksEntities();

        public static Expression<Func<Entities.Book, BookModel>> FromBookModel
        {
            get
            {
                return b => new BookModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    SubTitle = b.SubTitle,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    Pages = b.Pages,
                    Year = b.Year,
                    PublisherId = b.PublisherId,
                    ImageURL = b.ImageURL,
                    DownloadURL = b.DownloadURL,
                    UploaderId = b.UploaderUserId,
                    CategoryId = b.CategoryId
                };
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int? Pages { get; set; }
        public DateTime? Year { get; set; }
        public int PublisherId { get; set; }
        public string ImageURL { get; set; }
        public string DownloadURL { get; set; }
        public Guid? UploaderId { get; set; }
        public int CategoryId { get; set; }

        public BookModel()
        { }

        public BookModel(int id)
        {
            Entities.Book book = db.Books
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (book != null)
            {
                this.Id = book.Id;
                this.Title = book.Title;
                this.SubTitle = book.SubTitle;
                this.Description = book.Description;
                this.ISBN = book.ISBN;
                this.Pages = book.Pages;
                this.Year = book.Year;
                this.PublisherId = book.PublisherId;
                this.ImageURL = book.ImageURL;
                this.DownloadURL = book.DownloadURL;
                this.UploaderId = book.UploaderUserId;
                this.CategoryId = book.CategoryId;
            }
        }
    }
}