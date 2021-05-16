using System;
using System.Collections.Generic;
using System.Text;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System.Threading.Tasks;

namespace Shopping.BLayer.Interfaces
{
    
    interface IProductdetails{
        Task<ProductdetailsResponse> saveproduct(AddProductdetailRequest data, string filter); //0 for error 1 for sucessfull
        Task<List<ProductdetailsResponse>> getdetailbyUserId(int id, string filter);
        Task<ProductdetailsResponse> updatedetailsbyid(AddProductdetailRequest data, string filter);
        Task<ProductdetailsResponse> disableproductbyid(int id, string filter);// delete user 
        Task<ProductdetailsResponse> activeproductbyid(int id, string filter); // activate users
        Task<List<ProductdetailsResponse>> activeproductlist(string filter); //get all active user
        Task<List<ProductdetailsResponse>> disabledproductlist(string filter); //get all disable user
        Task<List<ProductdetailsResponse>> getdetailbyrating(int Rating, string filter);

        Task<ProductdetailsResponse> getdetailbyProductId(int id, string filter);
        Task<List<ProductdetailsResponse>> getdetailbyProductName(string name, string filter);


    }
}
