using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Models
{
    public class OrderLine
    {
        public int OrderLineID { get; set; }
        public int Quantity { get; set; }
        public Game Game { get; set; }
        public Order Order { get; set; }
    }
}