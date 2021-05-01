using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.BLayer.Adapters;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [Route("api/Ownerdetail")]
    public class OwnerdetailController : Controller
    {
        [Route("Adddetails")]
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] AdddetailsRequest request)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter();
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                response = await ad.savedetails(request);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }
    }
}
