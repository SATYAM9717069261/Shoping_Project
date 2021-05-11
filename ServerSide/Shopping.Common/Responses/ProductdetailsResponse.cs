using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class ProductdetailsResponse:BaseResponse
    {
        public string ProductName { get; set; }
        public long Price { get; set; }
        public long? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public int? Rating { get; set; }
    }
}
