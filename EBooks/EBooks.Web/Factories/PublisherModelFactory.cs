using EBooks.Web.Entities;
using EBooks.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace EBooks.Web.Factories
{
    public class PublisherModelFactory
    {
        private static EBooksEntities db = new EBooksEntities();

        public static List<PublisherModel> GetAll()
        {
            var publishers = db.Publishers
                .Select(x => new PublisherModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToList();

            return publishers;
        }
    }
}