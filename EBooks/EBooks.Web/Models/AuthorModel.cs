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

        internal void Update(string name)
        {
            Entities.Author author = db.Authors
                .Where(x => x.Id == this.Id)
                .FirstOrDefault();

            author.Name = name;

            db.SaveChanges();
        }

        internal static void Create(string name)
        {
            Entities.Author newAuthor = new Entities.Author()
            {
                Name = name
            };

            db.Authors.Add(newAuthor);
            db.SaveChanges();
        }

        internal void Delete()
        {
            List<Entities.Book> books = new List<Entities.Book>();

            Entities.Author author = db.Authors
                .Where(x => x.Id == this.Id)
                .FirstOrDefault();

            List<Entities.Book> allBooks = db.Books.ToList();

            foreach (var book in allBooks)
            {
                if (book.Authors.Contains(author))
                {
                    books.Add(book);
                }
            }

            foreach (var item in books)
            {
                item.Authors.Remove(author);
            }
            db.Authors.Remove(author);
            db.SaveChanges();
        }
    }
}