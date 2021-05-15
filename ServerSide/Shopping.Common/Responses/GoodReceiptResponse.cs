using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class GoodReceiptResponse:BaseResponse
    {
        public long? Grnumber { get; set; }
        public long ProductId { get; set; }

    }
}
