using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Requests
{
    public class OwnerdetailRequest:BaseRequest
    {
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
    }
    public class AdddetailsRequest : BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }

    }
    public class ModifyRequest: BaseRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
