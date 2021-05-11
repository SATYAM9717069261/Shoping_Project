using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Interfaces;
using Shopping.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.DataLayer.AutoMapperStructure;
using AutoMapper;
using Shopping.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Shopping.Common.Filters;

namespace Shopping.BLayer.Adapters
{
    public class OwnerdetailsAdapter : IOwnerdetails
    {
        private Ownerdetails details;
        private IMapper custommapper;
        private readonly AppDbContext dbconnection;
        public OwnerdetailsAdapter(IMapper Shoppingmapper,AppDbContext conn)
        {
            custommapper = Shoppingmapper;
            this.dbconnection = conn;
        }

        public async Task<OwnerdetailsResponse> activeuserbyid(int id, string filter)
        {
            details = new Ownerdetails();
            OwnerdetailsResponse response = new OwnerdetailsResponse();
            details =await (from a in dbconnection.Ownerdetails where a.UserId == id select a).FirstOrDefaultAsync();
            if (details != null) {
                details.IsActive = true;
                details.IsDelete = false;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Ownerdetails, OwnerdetailsResponse>(details);
                response.Sucess = row > 0;
            }
            else throw new CustomException("User Id is Not Valid");
            return response;
        }

        public async Task<List<OwnerdetailsResponse>> activeuserlist(string filter)
        {
            details = new Ownerdetails();
            List<OwnerdetailsResponse> response = new List<OwnerdetailsResponse>();
            var data= await (from a in dbconnection.Ownerdetails where a.IsActive == true select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<OwnerdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<OwnerdetailsResponse> disablebyid(int id, string filter)
        {
            details = new Ownerdetails();
            OwnerdetailsResponse response = new OwnerdetailsResponse();
            details =await (from a in dbconnection.Ownerdetails where a.UserId == id select a).FirstOrDefaultAsync();
            if (details != null)
            {
                details.IsActive = false;
                details.IsDelete = true;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Ownerdetails, OwnerdetailsResponse>(details);
                response.Sucess = row > 0;
            }
            else throw new CustomException("User Id is Not Valid");
            return response;
        }

        public async Task<List<OwnerdetailsResponse>> disableduserlist(string filter)
        {
            details = new Ownerdetails();
            List<OwnerdetailsResponse> response = new List<OwnerdetailsResponse>();
            var data = await (from a in dbconnection.Ownerdetails where a.IsDelete == true select a).ToListAsync();
            if (data.Count!=0) response = custommapper.Map<List<OwnerdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<OwnerdetailsResponse> getdetailbyId(int id, string filter)
        {
            details = new Ownerdetails();
            OwnerdetailsResponse response = new OwnerdetailsResponse();
            details = await (from a in dbconnection.Ownerdetails where  a.UserId==id select a).FirstOrDefaultAsync();

            if (details != null) response = custommapper.Map<Ownerdetails,OwnerdetailsResponse>(details);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<OwnerdetailsResponse> savedetails(AdddetailsRequest data, string filter)
        {
            details = new Ownerdetails();
            OwnerdetailsResponse response = new OwnerdetailsResponse();
            details = custommapper.Map<AdddetailsRequest, Ownerdetails>(data);
            details.CreatedOn = DateTime.UtcNow;
            details.ModifyOn = DateTime.UtcNow;
            details.IsActive = true;
            details.IsDelete = false;
            dbconnection.Ownerdetails.Add(details);
            var row = await dbconnection.SaveChangesAsync();
            response = custommapper.Map<Ownerdetails, OwnerdetailsResponse>(details);
            response.Sucess = row > 0;
            return response;
            
        }

        public async Task<OwnerdetailsResponse> updatedetailsbyid(ModifyRequest data, string filter)
        {
            details = new Ownerdetails();
            OwnerdetailsResponse response = new OwnerdetailsResponse();
            details = await(from a in dbconnection.Ownerdetails where a.UserId == data.UserId select a).FirstOrDefaultAsync();
            if(details != null){
                //details = custommapper.Map<ModifyRequest,Ownerdetails>(data);
                details.Username = data.UserName;
                details.Password = data.Password;
                details.ModifyOn = DateTime.UtcNow;
                details.IsActive = true;
                details.IsDelete = false;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Ownerdetails, OwnerdetailsResponse>(details);
                response.Sucess = row > 0;
            }else throw new CustomException("detail !");
            return response;
        }

    }
}
