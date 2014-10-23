using EBooks.Web.Factories;
using EBooks.Web.Models;
using System.Collections.Generic;
using System.Web.UI;

namespace EBooks.Web.UserControls
{
    public partial class PublisherSearch : UserControl
    {
        public List<PublisherModel> AllPublishers
        {
            get { return PublisherModelFactory.GetAll(); }
        }
    }
}