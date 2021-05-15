using Shopping.BLayer.Interfaces;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLayer.Adapters
{
    public class GoodReceiptMappingAdapter : IGoodReceiptMapping
    {
        public Task<GoodReceiptMappingResponse> disableGrMapping(int userid, int grid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<GoodReceiptMappingResponse> savedetails(GoodReceiptMappingRequest data, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<GoodReceiptMappingResponse> updatedetails(GoodReceiptMappingRequest data, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
