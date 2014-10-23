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

            if (Action == "Delete")
            {
                this.Name.Enabled = false;
            }

            if (!this.IsPostBack)
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
            try
            {
                string name = this.Name.Text;

                using (var db = new EBooksEntities())
                {
                    switch (this.Action)
                    {
                        case "Create":
                            db.Publishers.Add(new Entities.Publisher { Name = name });
                            break;
                        case "Update":
                            int id = int.Parse(PublisherId);
                            db.Publishers.Single(x => x.Id == id).Name = name;
                            break;
                        case "Delete":
                            id = int.Parse(PublisherId);
                            db.Publishers.Remove(db.Publishers.Single(x => x.Id == id));
                            break;
                        default:
                            break;
                    }
                    db.SaveChanges();
                    DisplayMessage("item succesfully updated", "success");
                }
            }
            catch (Exception ex)
            {
                switch (this.Action)
                {
                    case "Create":
                        DisplayMessage("There was an error creating the item", "danger");
                        return;
                    case "Update":
                        DisplayMessage("There was an error while updating the item", "danger");
                        return;
                    case "Delete":
                        DisplayMessage("Error: unable to delete item, please check if any books are related to this Publisher and delete them first", "danger");
                        return;
                    default:
                        break;
                }
            }
        }

        protected void DisplayMessage(string message, string type)
        {
            string cssClass = string.Format("alert alert-dismissable alert-{0}", type);
            this.StatusPanel.Text = message;
            this.StatusPanel.CssClass = cssClass;
            this.StatusPanel.Visible = true;
        }

    }
}