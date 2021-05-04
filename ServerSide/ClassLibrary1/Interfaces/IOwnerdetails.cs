using Shopping.Common.Filters;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.DataLayer.Interfaces
{
    interface IOwnerdetails
    {
        Task<OwnerdetailsResponse> savedetails(AdddetailsRequest data, string filter); //0 for error 1 for sucessfull
        Task<OwnerdetailsResponse> getdetailbyId(int id, string filter);
        Task<OwnerdetailsResponse> updatedetailsbyid(ModifyRequest data, string filter);
        Task<OwnerdetailsResponse> disablebyid(int id, string filter);// delete user
        Task<OwnerdetailsResponse> activeuserbyid(int id, string filter); // activate users
        Task<List<OwnerdetailsResponse>> activeuserlist(string filter); //get all active user
        Task<List<OwnerdetailsResponse>> disableduserlist(string filter); //get all disable user
    }
}
