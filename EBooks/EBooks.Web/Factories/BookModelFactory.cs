using EBooks.Web.Entities;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBooks.Web.Factories
{
    public class BookModelFactory
    {
        private static EBooksEntities db = new EBooksEntities();

        public static BookModel GetBookById(int bookId)
        {
            List<BookModel> searchedBook = db.Books
                        .Where(book => book.Id == bookId)
                        .Select(x => new BookModel
                        {
                            Id = x.Id,
                            Title = x.Title,
                            SubTitle = x.SubTitle,
                            Description = x.Description,
                            ISBN = x.ISBN,
                            Pages = x.Pages,
                            Year = x.Year,
                            PublisherId = x.PublisherId,
                            ImageURL = x.ImageURL,
                            DownloadURL = x.DownloadURL,
                            UploaderId = x.UploaderUserId,
                            CategoryId = x.CategoryId
                        }).ToList();

            return searchedBook[0];
        }

        public static List<BookModel> GetAllBooksByCategory(int categoryId)
        {
            var books = db.Books
                    .Where(x => x.Id == categoryId)
                    .Select(x => new BookModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        SubTitle = x.SubTitle,
                        Description = x.Description,
                        ISBN = x.ISBN,
                        Pages = x.Pages,
                        Year = x.Year,
                        PublisherId = x.PublisherId,
                        ImageURL = x.ImageURL,
                        DownloadURL = x.DownloadURL,
                        UploaderId = x.UploaderUserId,
                        CategoryId = x.CategoryId
                    })
                    .ToList();

            return books;
        }

        public static List<BookModel> GetAll()
        {
            var books = db.Books
                    .Select(x => new BookModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        SubTitle = x.SubTitle,
                        Description = x.Description,
                        ISBN = x.ISBN,
                        Pages = x.Pages,
                        Year = x.Year,
                        PublisherId = x.PublisherId,
                        ImageURL = x.ImageURL,
                        DownloadURL = x.DownloadURL,
                        UploaderId = x.UploaderUserId,
                        CategoryId = x.CategoryId
                    })
                    .ToList();

            return books;
        }

        public static BookModel GetModel(string queryString)
        {
            int modelId;
            int.TryParse(queryString, out modelId);

            if (modelId != 0)
            {
                var model = db.Books
                    .Where(x => x.Id == modelId)
                    .Select(x => new BookModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        SubTitle = x.SubTitle,
                        Description = x.Description,
                        ISBN = x.ISBN,
                        Pages = x.Pages,
                        Year = x.Year,
                        PublisherId = x.PublisherId,
                        ImageURL = x.ImageURL,
                        DownloadURL = x.DownloadURL,
                        UploaderId = x.UploaderUserId,
                        CategoryId = x.CategoryId,

                    })
                    .FirstOrDefault();
                model.Authors = AuthorModelFactory.GetAllBookAuthors(modelId);

                return model;
            }

            return null;
        }
    }
}