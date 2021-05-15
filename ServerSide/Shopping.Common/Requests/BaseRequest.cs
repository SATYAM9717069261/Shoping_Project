using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Requests
{
    public class BaseRequest {
        public long? UserId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        

    }
    public class ProductBaseRequest {
        public long? ProductId { get; set; }
        public long? OwnerdetailUserId { get; set; }
    }

    public class GrBaseRequest
    {
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
    }
    
}
