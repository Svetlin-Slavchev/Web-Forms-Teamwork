using EBooks.Web.Factories;
using EBooks.Web.Models;
using System.Collections.Generic;
using System.Web.UI;

namespace EBooks.Web.UserControls
{
    public partial class CategorySearch : UserControl
    {
        public List<CategoryModel> AllCategories
        {
            get { return CategoryModelFactory.GetAll(); }
        }
    }
}