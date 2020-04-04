using System;
using System.Collections.Generic;
using System.Text;

namespace OMF.Common.Models
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public Menu Item { get; set; }
    }
}
