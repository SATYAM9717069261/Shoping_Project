using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Requests
{
    public class GoodReceiptRequest: GrBaseRequest
    {
        public long ? Grnumber { get; set; }
        public long? OwnerdetailUserId { get; set; }
        public long? ProductdetailProductId { get; set; }
        public string CustomerName { get; set; }
        public string? BillNumber { get; set; }
    }
}
