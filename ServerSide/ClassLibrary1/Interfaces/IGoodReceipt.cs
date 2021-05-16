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
        Task<GoodReceiptResponse> updatedetailsbyGrnmber(GoodReceiptRequest data, string filter);
        Task<List<GoodReceiptResponse>> updatecustomernamebyBillnmber(GoodReceiptRequest data, string filter);
        Task<GoodReceiptResponse> getdetailbyGrnumber(int? grnum, long? userid, string filter);
        Task<List<GoodReceiptResponse>> getdetailbyBillnumber(string billnum, long? userid, string filter);
        Task<List<GoodReceiptResponse>> getdetailsbyProductid(long? productid, long? userid, string filter);
        Task<List<GoodReceiptResponse>> getdetailsbyUserId(int? userid, string filter);
    }
}
