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

        public Ownerdetails getdetailswithfilters(Ownerdetails filterdetails)
        {
            throw new NotImplementedException();
        }

        public List<Ownerdetails> getlistdetailswithfilters(Ownerdetails filterdetails)
        {
            throw new NotImplementedException();
        }

        public Ownerdetails savedetails(AdddetailsRequest data)
        {
            details = new Ownerdetails()
            {
                UserId = 1
            };
            return details;
            
        }

        public Ownerdetails updatedetailsbyid(int id)
        {
            throw new NotImplementedException();
        }

    }
}
