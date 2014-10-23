using EBooks.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.Publishers
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            using (var db = new EBooksEntities())
            {
                this.PublishersData.DataSource = db.Publishers.ToList();
                this.PublishersData.DataBind();
            }
        }
    }
}