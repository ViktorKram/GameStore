using System;
using System.Collections.Generic;
using GameStore.Models;
using GameStore.Models.Repository;
using GameStore.Pages.Helpers;
using System.Web.ModelBinding;

namespace GameStore.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order order = new Order();

                if(TryUpdateModel(order, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    order.OrderLines = new List<OrderLine>();

                    Cart cart = SessionHelper.GetCart(Session);

                    foreach(CartLine line in cart.Lines)
                    {
                        order.OrderLines.Add(new OrderLine
                        {
                            Order = order,
                            Game = line.Game,
                            Quantity = line.Quantity
                        });
                    }

                    new Repository().SaveOrder(order);
                    cart.Clear();

                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }

                
            }
        }
    }
}