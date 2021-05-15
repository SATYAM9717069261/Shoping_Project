using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.Common.Requests
{
    public class GoodReceiptRequest:BaseRequest
    {
        [Key]
        public long ? Grnumber { get; set; }
        public long ProductId { get; set; }
    }
}
