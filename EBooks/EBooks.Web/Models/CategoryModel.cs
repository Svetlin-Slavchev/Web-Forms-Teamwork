using EBooks.Web.Entities;
using EBooks.Web.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBooks.Web.Models
{
    public class CategoryModel
    {
        private static EBooksEntities db = new EBooksEntities();

        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookModel> Books { get; set; }

        public CategoryModel()
        { }

        public CategoryModel(int id)
        {
            Entities.Category category = db.Categories
                .Where(x => x.Id == id)
                .FirstOrDefault();

            if (category != null)
            {
                this.Id = category.Id;
                this.Name = category.Name;
                this.Books = BookModelFactory.GetAllBooksForCategory(this.Id);
            }
        }
    }
}