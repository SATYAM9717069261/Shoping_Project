using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class GoodReceiptResponse:BaseResponse
    {
        public long? Grnumber { get; set; }
        public long? OwnerdetailUserId { get; set; }
        public long ? ProductdetailProductId { get; set; }
        public string? BillNumber { get; set; }
        public string CustomerName { get; set; }

    }
}
