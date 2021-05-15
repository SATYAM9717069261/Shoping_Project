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
        Task<GoodReceiptMappingResponse> savedetails(GoodReceiptMappingRequest data, string filter);
        Task<GoodReceiptMappingResponse> updatedetails(GoodReceiptMappingRequest data, string filter);
        // disable all mapping of user except grid which you pass
        Task<GoodReceiptMappingResponse> disableGrMapping(int userid,int grid, string filter);
        
    }
}
