using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Interfaces
{
    interface IOwnerdetails
    {
        Task<OwnerdetailsResponse> savedetails(AdddetailsRequest data); //0 for error 1 for sucessfull
        Ownerdetails getdetails(int id);
        Ownerdetails updatedetailsbyid(int id);
        Ownerdetails disablebyid(int id);// delete user
        Ownerdetails activeuserbyid(int id); // activate users
        List<Ownerdetails> activeuserlist(); //get all active user
        List<Ownerdetails> disableduserlist(); //get all disable user
        Ownerdetails getdetailswithfilters(AdddetailsRequest filterdetails);// get details (filter)
        List<Ownerdetails> getlistdetailswithfilters(AdddetailsRequest filterdetails); // get list of details on filter bases
    }
}
