using EBooks.Web.Factories;
using EBooks.Web.Models;
using System.Collections.Generic;
using System.Web.UI;

namespace EBooks.Web.UserControls
{
    public partial class AuthorSearch : UserControl
    {
        public List<AuthorModel> AllAuthors
        {
            get { return AuthorModelFactory.GetAll(); }
        }
    }
}