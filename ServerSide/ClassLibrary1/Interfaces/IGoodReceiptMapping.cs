using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLayer.Interfaces
{
    interface IGoodReceiptMapping
    {
        Task<GoodReceiptMappingResponse> save(GoodReceiptMappingRequest data);
        
    }
}
