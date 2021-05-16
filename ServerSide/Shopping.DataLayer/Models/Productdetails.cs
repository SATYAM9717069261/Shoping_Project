using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Models
{
    public class Productdetails
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public long Quantity { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public int Rating { get; set; }
    }
}
