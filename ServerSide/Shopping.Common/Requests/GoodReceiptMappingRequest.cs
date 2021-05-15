using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shopping.Common.Requests
{
    public class GoodReceiptMappingRequest: BaseRequest
    {
        [Key]
        public long? mappedid { get; set; }
        public string  logo { get; set; }
        public string  header { get; set; }
        
    }
}
