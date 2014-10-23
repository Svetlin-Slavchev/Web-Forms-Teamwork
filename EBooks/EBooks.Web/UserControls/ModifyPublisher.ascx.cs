using EBooks.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EBooks.Web.UserControls
{
    public partial class ModifyPublisher : System.Web.UI.UserControl
    {
        public string PublisherId { get; set; }

        public string Action { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            this.ModifyButton.Text = this.Action;

            if (PublisherId == null && Action != "Create")
            {
                throw new InvalidOperationException("InvalidRequest");
            }

            if (!this.IsPostBack )
            {
                try
                {
                    int id = int.Parse(this.PublisherId);
                    using (var db = new EBooksEntities())
                    {
                        this.Name.Text = db.Publishers.Single(x => x.Id == id).Name;
                    }
                }
                catch (Exception) { }
            }
        }

        protected void ModifyButton_Click(object sender, EventArgs e)
        {
            string name = this.Name.Text;
            int id = int.Parse(PublisherId);

            using (var db = new EBooksEntities())
            {
                switch (this.Action)
                {
                    case "Create":
                        db.Publishers.Add(new Entities.Publisher { Name = name });
                        break;
                    case "Update":
                        db.Publishers.Single(x => x.Id == id).Name = name;
                        break;
                    case "Delete":
                        db.Publishers.Remove(db.Publishers.Single(x => x.Id == id));
                        break;
                    default:
                        break;
                }
                db.SaveChanges();
                Response.Redirect("~/Publisher/");
            }
        }
    }
}