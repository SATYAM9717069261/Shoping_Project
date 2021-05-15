using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
namespace Shopping.Common.Requests
{
    public class AddProductdetailRequest: ProductBaseRequest
    {
        public string ProductName { get; set; }
        public long Price { get; set; }
        public long? Quantity { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public long? Rating { get; set; }
        public IFormFile ImageContent { get; set; }
    }
}
