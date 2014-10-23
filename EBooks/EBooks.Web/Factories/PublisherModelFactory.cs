using EBooks.Web.Entities;
using EBooks.Web.Models;
using System.Collections.Generic;
using System.Linq;

namespace EBooks.Web.Factories
{
    public static class PublisherModelFactory
    {
        public static List<PublisherModel> GetAll()
        {
            using (var db = new EBooksEntities())
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
}