using AutoMapper;
using Shopping.BLayer.Interfaces;
using Shopping.Common.Exceptions;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shopping.BLayer.Adapters
{
    public class GoodRceiptAdapter : IGoodReceipt
    {
        private GoodRecipt details;
        private IMapper custommapper;
        private Ownerdetails ownerdetails;
        private readonly AppDbContext dbconnection;
        public GoodRceiptAdapter(IMapper Shoppingmapper, AppDbContext conn)
        {
            custommapper = Shoppingmapper;
            this.dbconnection = conn;
        }
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

        public async Task<GoodReceiptResponse> savedetails(GoodReceiptRequest data, string filter)
        {
            /**  var chk_User_pro = await (from a in dbconnection.Ownerdetails
                                    join  b in dbconnection.Productdetails
                                    on a.UserId equals b.OwnerdetailUserId
                                    where a.UserId == data.UserId && b.ProductId == data.ProductId 
                                          && a.IsActive == true && a.IsDelete == false
                                          && b.IsActive == true && b.IsDelete == false
                                    select a).FirstOrDefaultAsync()  ;
              if (chk_User_pro == null) { throw new CustomException("User Id Or Product Id Not Found !"); } */

            var chk_usr = await (from a in dbconnection.Ownerdetails
                                 where a.UserId == data.OwnerdetailUserId && a.IsActive == true && a.IsDelete == false
                                 select a).FirstOrDefaultAsync();
            var chk_pro = await (from a in dbconnection.Productdetails
                                 where a.ProductId == data.ProductdetailProductId && a.IsActive == true && a.IsDelete == false
                                 select a).FirstOrDefaultAsync();

            if (chk_usr == null || chk_pro == null) { return (new GoodReceiptResponse() { Sucess = false }); }
            details = new GoodRecipt();
            GoodReceiptResponse response = new GoodReceiptResponse();
            details = custommapper.Map<GoodReceiptRequest, GoodRecipt>(data);
            details.CreatedOn = DateTime.UtcNow;
            details.ModifyOn = DateTime.UtcNow;
            details.IsActive = true;
            details.IsDelete = false;
            dbconnection.GoodRecipt.Add(details);
            var row = await dbconnection.SaveChangesAsync();
            response = custommapper.Map<GoodRecipt, GoodReceiptResponse>(details);
            response.Sucess = row > 0;
            return response;
        }

        public async Task<GoodReceiptResponse> updatedetails(GoodReceiptRequest data, string filter)
        {
            details = new GoodRecipt();
            details = await(from a in dbconnection.GoodRecipt
                                where a.Grnumber == data.Grnumber && a.IsActive == true && a.IsDelete == false
                                select a).FirstOrDefaultAsync();


            if (details == null) { throw new CustomException("Recept Id is not valid"); }
            
            GoodReceiptResponse response = new GoodReceiptResponse();
            //details = custommapper.Map<GoodReceiptRequest, GoodRecipt>(data);
            if (data.ProductdetailProductId != null) { details.ProductdetailProductId = data.ProductdetailProductId; }
            if (data.OwnerdetailUserId != null) { details.OwnerdetailUserId = data.OwnerdetailUserId; }
            details.IsActive = true;
            details.IsDelete = false;
            if (data.CustomerName != null){ details.CustomerName = data.CustomerName; }
            if (data.BillNumber != null) {  details.BillNumber = data.BillNumber; }
            details.ModifyOn= DateTime.UtcNow; 
            var row = await dbconnection.SaveChangesAsync();
            response = custommapper.Map<GoodRecipt, GoodReceiptResponse>(details);
            response.Sucess = row > 0;
            return response;
        }
    }
}
