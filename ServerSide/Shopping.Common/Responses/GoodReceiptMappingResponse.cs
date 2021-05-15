using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Common.Responses
{
    public class GoodReceiptMappingResponse:BaseResponse
    {
        public long mappedid { get; set; }
        public string logo { get; set; } 
        public string header { get; set; }
    }
}
