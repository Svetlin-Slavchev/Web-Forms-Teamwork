using EBooks.Web.Factories;
using EBooks.Web.Models;
using System.Collections.Generic;
using System.Web.UI;

namespace EBooks.Web.UserControls
{
    public partial class BookSearch : UserControl
    {
        public List<BookModel> AllBooks
        {
            get { return BookModelFactory.GetAll(); }
        }
    }
}