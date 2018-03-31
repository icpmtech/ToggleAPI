using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Routing;
using ToggleAPI.Models;

namespace ToggleAPI.Helpers
{
    public static class Utils
    {
        public static IEnumerable<Link> CreateLinks(ToggleViewModel toggleViewModel)
        {
            UrlHelper Url = new UrlHelper();
            var links = new[]
            {
        new Link
        {
            Method = "GET",
            Rel = "self",
            Href = Url.Link("GetDeliveryById", new {id = toggleViewModel.Id})
        },
        new Link
        {
            Method = "PUT",
            Rel = "status-delivered",
            Href = Url.Link("ChangeStatusById", new {id = toggleViewModel.Id, status = "delivered"})
        }
    };
            return links;
        }
    }
}