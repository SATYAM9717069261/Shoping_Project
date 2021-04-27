using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    public class OwnerdetailController : Controller
    {
        private OwnerdetailsResponse response;
        public async Task<ActionResult> AddUser([FromBody] AdddetailsRequest request)
        {
            response = new OwnerdetailsResponse();
            
            return Ok(response);
        }
    }
}
