﻿using EBooks.Web.Entities;
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

        public static List<BookModel> GetAllBooksForCategory(int categoryId)
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
    }
}