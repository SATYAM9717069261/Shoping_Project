using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class OwnerdetailsResponse : BaseResponse
    {
        public long UserId { get; set; }
        public bool IsExist { get; set; }
    }
}
