using Amazon.Runtime.Internal;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.BLayer.Adapters;
using Shopping.Common.Exceptions;
using Shopping.Common.Filters;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [Route("api/Ownerdetail")]
    public class OwnerdetailController : Controller
    {
        private readonly IMapper Shoppingmapper;
        private readonly AppDbContext dbconnection;
        public OwnerdetailController(IMapper mapper, AppDbContext conn){
            Shoppingmapper = mapper;
            this.dbconnection = conn;
        }

        [Route("Adddetails")]
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] AdddetailsRequest request, [FromBody]string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper,dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                response = await ad.savedetails(request, filter);
                if (response.Sucess == false) throw new CustomException("User Id is not mention");
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
           
        }
        [Route("ActivateId/{id?}")]
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> ActivateId(int? id,[FromBody] string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                if (id != null) response = await ad.activeuserbyid((int)id,filter);
                else throw new CustomException("User Id is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
        [Route("ActivateIds/{filter?}")]
        [HttpGet]
        public async Task<IActionResult> ActivateIds(string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                List<OwnerdetailsResponse> response = new List<OwnerdetailsResponse>();
                response = await ad.activeuserlist(filter);
                if(response==null) throw new CustomException("No data Found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
        [Route("DisabledIds")]
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DisableIds([FromBody] string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                response = await ad.disableduserlist(filter);
                if (response == null) throw new CustomException("No data Found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
        [Route("DisableId/{id?}")]
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> DisableId(int? id, [FromBody] string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                if (id != null) response = await ad.disablebyid((int)id, filter);
                else throw new CustomException("User Id is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [Route("GetdetailsbyId/{id?}")]
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> GetdetailsbyId(int? id, [FromBody] string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                if (id != null) response = await ad.getdetailbyId((int)id, filter);
                else throw new CustomException("User Id is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [Route("Updatedetails")]
        [HttpPost]
        public async Task<IActionResult> Updatedetails([FromBody] ModifyRequest request, [FromBody] string filter)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                response = await ad.updatedetailsbyid(request, filter);
                if (response.Sucess == null) throw new CustomException("Internal Server Error");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
