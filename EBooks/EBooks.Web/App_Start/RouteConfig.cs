using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace EBooks.Web
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.MapPageRoute("Publisher",
                    "Publisher/{id}",
                    "~/Publisher/View.aspx");

            routes.MapPageRoute("ModifyPublisher",
                "Publisher/{id}/{action}",
                "~/Publisher/{action}.aspx");
        }
    }
}
