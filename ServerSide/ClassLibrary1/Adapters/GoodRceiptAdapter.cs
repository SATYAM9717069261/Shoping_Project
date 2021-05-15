using Shopping.BLayer.Interfaces;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLayer.Adapters
{
    public class GoodRceiptAdapter : IGoodReceipt
    {
        public Task<GoodReceiptResponse> activebyid(int productid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<GoodReceiptResponse> disablebyid(int productid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<GoodReceiptResponse>> getactiveproductsbyuserid(int userid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<GoodReceiptResponse> getdetailbyGrnumber(int grnum, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<GoodReceiptResponse>> getdetailsbyProductid(int productid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<GoodReceiptResponse>> getdetailsbyUserId(int userid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<GoodReceiptResponse>> getdisabledproductsbyuserid(int userid, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<GoodReceiptResponse> savedetails(GoodReceiptRequest data, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<GoodReceiptResponse> updatedetails(GoodReceiptRequest data, string filter)
        {
            throw new NotImplementedException();
        }
    }
}
