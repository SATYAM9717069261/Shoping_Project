using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Interfaces;
using Shopping.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.BLayer.Adapters
{
    public class OwnerdetailsAdapter : IOwnerdetails
    {
        private Ownerdetails details;
        public Ownerdetails activeuserbyid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ownerdetails> activeuserlist()
        {
            throw new NotImplementedException();
        }

        public Ownerdetails disablebyid(int id)
        {
            throw new NotImplementedException();
        }

        public List<Ownerdetails> disableduserlist()
        {
            throw new NotImplementedException();
        }

        public Ownerdetails getdetails(int id)
        {
            throw new NotImplementedException();
        }

        public Ownerdetails getdetailswithfilters(AdddetailsRequest filterdetails)
        {
            throw new NotImplementedException();
        }

        public List<Ownerdetails> getlistdetailswithfilters(AdddetailsRequest filterdetails)
        {
            throw new NotImplementedException();
        }

        public async Task<OwnerdetailsResponse> savedetails(AdddetailsRequest data)
        {
            details = new Ownerdetails();
            OwnerdetailsResponse response = new OwnerdetailsResponse();
            details.Username = data.UserName;
            details.CreatedOn = DateTime.UtcNow;
            details.IsActive = true;
            details.IsDelete = false;
            details.ModifyOn = DateTime.UtcNow;
            response.Sucess = true;
            return response;
            
        }

        public Ownerdetails updatedetailsbyid(int id)
        {
            throw new NotImplementedException();
        }

    }
}
