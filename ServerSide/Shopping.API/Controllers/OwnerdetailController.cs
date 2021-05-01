using Amazon.Runtime.Internal;
using AutoMapper;
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
        private readonly IMapper Shoppingmapper;

        public OwnerdetailController(IMapper mapper)
        {
            Shoppingmapper = mapper;
        }

        [Route("Adddetails")]
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] AdddetailsRequest request)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper);
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
