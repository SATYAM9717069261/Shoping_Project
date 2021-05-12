using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class ProductdetailsResponse:BaseResponse
    {
        public long ProductId { get; set; }
        public long OwnerdetailUserId { get; set; }
        public string ProductName { get; set; }
        public long Price { get; set; }
        public long? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public long? Rating { get; set; }
    }
}
