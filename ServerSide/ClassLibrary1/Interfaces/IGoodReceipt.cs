using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLayer.Interfaces
{
    interface IGoodReceipt
    {
        Task<GoodReceiptResponse> savedetails(GoodReceiptRequest data, string filter);
        Task<GoodReceiptResponse> updatedetails(GoodReceiptRequest data, string filter);
        Task<GoodReceiptResponse> getdetailbyGrnumber(int grnum, string filter);
        Task<List<GoodReceiptResponse>> getdetailsbyProductid(int productid, string filter);
        Task<List<GoodReceiptResponse>> getdetailsbyUserId(int userid, string filter);
        Task<GoodReceiptResponse> disablebyid(int productid, string filter);
        Task<GoodReceiptResponse> activebyid(int productid, string filter);
        Task<List<GoodReceiptResponse>> getdisabledproductsbyuserid(int userid, string filter);
        Task<List<GoodReceiptResponse>> getactiveproductsbyuserid(int userid, string filter);
    }
}
