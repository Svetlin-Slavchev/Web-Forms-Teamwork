using EBooks.Web.Entities;
using EBooks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBooks.Web.Factories
{
    public class CategoryModelFactory
    {
        private static EBooksEntities db = new EBooksEntities();

        public static CategoryModel GetModel(string queryString)
        {
            int modelId;
            int.TryParse(queryString, out modelId);

            if (modelId != 0)
            {
                var model = db.Categories
                    .Where(x => x.Id == modelId)
                    .Select(x => new CategoryModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .FirstOrDefault();

                model.Books = BookModelFactory.GetAllBooksForCategory(modelId);

                return model;
            }

            return null;
        }

        public static List<CategoryModel> GetAll()
        {
            var categories = db.Categories
                .Select(x => new CategoryModel
                {
                    Id = x.Id,
                    Name = x.Name
                });

            foreach (var category in categories)
            {
                category.Books = BookModelFactory.GetAllBooksForCategory(category.Id);
            }

            return categories.ToList();
        }   
    }
}