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
        Task<List<GoodReceiptResponse>> updatecustomernamebyGrnmber(GoodReceiptRequest data, string filter);
        Task<GoodReceiptResponse> getdetailbyGrnumber(int? grnum, string filter);
        Task<List<GoodReceiptResponse>> getdetailbyBillnumber(string billnum, string filter);
        Task<List<GoodReceiptResponse>> getdetailsbyProductid(int? productid,int? userid , string filter);
        Task<List<GoodReceiptResponse>> getdetailsbyUserId(int? userid, string filter);
    }
}
