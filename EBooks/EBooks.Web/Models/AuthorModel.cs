using EBooks.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace EBooks.Web.Models
{
    public class AuthorModel
    {
        private static EBooksEntities db = new EBooksEntities();

        public static Expression<Func<Entities.Author, AuthorModel>> FromAuthorModel
        {
            get
            {
                return a => new AuthorModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Books = a.Books.AsQueryable().Select(BookModel.FromBookModel).ToList()
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookModel> Books { get; set; }

        public AuthorModel()
        {
        }

        public AuthorModel(int id)
        {
            Entities.Author author = db.Authors
               .Where(x => x.Id == id)
               .FirstOrDefault();

            if (author != null)
            {
                this.Id = author.Id;
                this.Name = author.Name;
                this.Books = author.Books.AsQueryable().Select(BookModel.FromBookModel).ToList();
            }
        }
    }
}