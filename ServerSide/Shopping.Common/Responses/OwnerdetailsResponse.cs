using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class OwnerdetailsResponse : BaseResponse
    {
        public long UserId { get; set; }
        public string Username { get; set; }

        public static implicit operator OwnerdetailsResponse(List<OwnerdetailsResponse> v)
        {
            throw new NotImplementedException();
        }
    }
}
