using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore.Models
{
    public class CartLine
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}