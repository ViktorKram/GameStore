using System;
using System.Linq;
using GameStore.Models;
using System.Web.Routing;
using GameStore.Pages.Helpers;

namespace GameStore.Controls
{
    public partial class CartSummary : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart cart = SessionHelper.GetCart(Session);
            csQuantity.InnerText = cart.Lines.Sum(x => x.Quantity).ToString();
            csTotal.InnerText = cart.ComputeTotalValue().ToString("c");
            csLink.HRef = RouteTable.Routes.GetVirtualPath(null, "cart", null).VirtualPath;
        }
    }
}