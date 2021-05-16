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
        private List<GoodRecipt> Listdetails;
        private IMapper custommapper;
        private readonly AppDbContext dbconnection;
        public GoodRceiptAdapter(IMapper Shoppingmapper, AppDbContext conn)
        {
            custommapper = Shoppingmapper;
            this.dbconnection = conn;
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

        public async Task<GoodReceiptResponse> updatedetailsbyGrnmber(GoodReceiptRequest data, string filter)
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

       
        public async Task<List<GoodReceiptResponse>> updatecustomernamebyBillnmber(GoodReceiptRequest data, string filter)
        {
            Listdetails = new List<GoodRecipt>();
            List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
            Listdetails = await (from a in dbconnection.GoodRecipt
                   where a.OwnerdetailUserId == data.OwnerdetailUserId && a.BillNumber == data.BillNumber && a.IsActive == true && a.IsDelete == false
                   select a).ToListAsync();
            if(Listdetails.Count() ==0 ) { throw new CustomException("Bill Number is not Valid"); }
            int i = 0;
            foreach(GoodRecipt details in Listdetails)
            {
                details.CustomerName = data.CustomerName;
                details.ModifyOn = DateTime.UtcNow;
                var row = await dbconnection.SaveChangesAsync();
                response.Add(custommapper.Map<GoodRecipt, GoodReceiptResponse>(details));
                response[i++].Sucess = row>0;
            }
            return response;
        }

        public async Task<GoodReceiptResponse> getdetailbyGrnumber(int? grnum, long? userid, string filter)
        {
            details = new GoodRecipt();
            GoodReceiptResponse response = new GoodReceiptResponse();
            details = await(from a in dbconnection.GoodRecipt
                                where a.OwnerdetailUserId == userid && a.IsActive == true &&
                                a.IsDelete == false && a.Grnumber==grnum
                                select a).FirstOrDefaultAsync() ;
            if (details == null) { throw new CustomException("User Id is not Valid"); }
            response=custommapper.Map<GoodRecipt, GoodReceiptResponse>(details);

            return response;
        }

        public async Task<List<GoodReceiptResponse>> getdetailbyBillnumber(string billnum, long? userid, string filter)
        {
            Listdetails = new List<GoodRecipt>();
            List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
            Listdetails = await(from a in dbconnection.GoodRecipt
                                where a.OwnerdetailUserId == userid && a.IsActive == true &&
                                a.IsDelete == false && a.BillNumber==billnum
                                select a).ToListAsync();
            if (Listdetails.Count() == 0) { throw new CustomException("User Id is not Valid"); }
            int i = 0;
            foreach (GoodRecipt details in Listdetails)
            {
                response.Add(custommapper.Map<GoodRecipt, GoodReceiptResponse>(details));
                response[i++].Sucess =true;
            }

            return response;
        }

        public async Task<List<GoodReceiptResponse>> getdetailsbyProductid(long? productid, long? userid, string filter)
        {
            Listdetails = new List<GoodRecipt>();
            List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
            Listdetails = await (from a in dbconnection.GoodRecipt
                                 where a.OwnerdetailUserId == userid && a.IsActive == true && 
                                 a.IsDelete == false && a.ProductdetailProductId==productid
                                 select a).ToListAsync(); ;
            if (Listdetails.Count() == 0) { throw new CustomException("User Id is not Valid"); }
            int i = 0;
            foreach (GoodRecipt details in Listdetails)
            {
                response.Add(custommapper.Map<GoodRecipt, GoodReceiptResponse>(details));
                response[i++].Sucess = true;
            }

            return response;
        }

        public async Task<List<GoodReceiptResponse>> getdetailsbyUserId(int? userid, string filter)
        {
            Listdetails = new List<GoodRecipt>();
            List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
            Listdetails = await(from a in dbconnection.GoodRecipt
                                where a.OwnerdetailUserId == userid && a.IsActive == true && a.IsDelete == false
                                select a).ToListAsync();
            if (Listdetails.Count() == 0) { throw new CustomException("User Id is not Valid"); }
            int i = 0;
            foreach (GoodRecipt details in Listdetails)
            {
                response.Add(custommapper.Map<GoodRecipt, GoodReceiptResponse>(details));
                response[i++].Sucess = true;
            }

            return response;
        }
    }
}
