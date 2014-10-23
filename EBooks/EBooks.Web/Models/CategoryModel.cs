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
                this.Books = BookModelFactory.GetAllBooksByCategory(this.Id);
            }
        }

        internal static void Create(string name)
        {
            Entities.Category newCategory = new Entities.Category()
                {
                    Name = name
                };

            db.Categories.Add(newCategory);
            db.SaveChanges();
        }

        internal void Update(string name)
        {
            Entities.Category category = db.Categories
                .Where(x => x.Id == this.Id)
                .FirstOrDefault();

            category.Name = name;

            db.SaveChanges();
        }

        internal bool Delete()
        {
            Entities.Category category = db.Categories
                .Where(x => x.Id == this.Id)
                .FirstOrDefault();

            var booksInCategory = db.Books.Where(b => b.CategoryId == category.Id);
            if (booksInCategory.Count() == 0)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }

            return false;
        }
    }
}