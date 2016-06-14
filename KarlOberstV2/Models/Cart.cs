using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KarlOberstV2.Models
{
    public class Cart
    {
        public List<ItemCart> Items { get; set; }
        public float Subtotal { get; set; }
        public float Total { get; set; }
    }
}