﻿using EBooks.Web.Entities;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBooks.Web.Factories
{
    public class AuthorModelFactory
    {
        private static EBooksEntities db = new EBooksEntities();

        public static List<AuthorModel> GetAll()
        {
            var authors = db.Authors
                .Select(x => new AuthorModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            //foreach (var category in authors)
            //{
            //    authors.Books = BookModelFactory.GetAllBooksForCategory(category.Id);
            //}

            return authors.ToList();
        }

        public static AuthorModel GetModel(string queryString)
        {
            int modelId;
            int.TryParse(queryString, out modelId);

            if (modelId != 0)
            {
                var model = db.Authors
                    .Where(x => x.Id == modelId)
                    .Select(x => new AuthorModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Books = x.Books.AsQueryable().Select(BookModel.FromBookModel).ToList()
                    })
                    .FirstOrDefault();

                return model;
            }

            return null;
        }
    }
}