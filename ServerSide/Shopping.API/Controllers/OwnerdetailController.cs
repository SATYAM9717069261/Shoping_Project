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
    [Route("api/Owner")]
    public class OwnerdetailController : Controller
    {
        private string filter = null;
        private readonly IMapper Shoppingmapper;
        private readonly AppDbContext dbconnection;
        public OwnerdetailController(IMapper mapper, AppDbContext conn){
            Shoppingmapper = mapper;
            this.dbconnection = conn;
        }

        [Route("Adddetails")]
        [HttpPost]
        public async Task<IActionResult> AddOwner([FromBody] AdddetailsRequest request)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper,dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                if(request.UserName != null && request.Password!=null) response = await ad.savedetails(request, filter);
                else throw new CustomException("User Name and Password didn't Mention !");
                if (response.Sucess == false) throw new CustomException("Internal Server Error !");
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
           
        }
        [Route("ActivateId/{id?}")]
        [HttpGet]
        public async Task<IActionResult> ActivateId(int? id)
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
        [Route("ActivateIds")]
        [HttpGet]
        public async Task<IActionResult> ActivateIds()
        {
            try{
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                List<OwnerdetailsResponse> response = new List<OwnerdetailsResponse>();
                response = await ad.activeuserlist(filter);
                if(response==null) throw new CustomException("No data Found");
                return Ok(response);
            }catch (Exception ex){
                return Ok(ex.Message);
            }
        }
        [Route("DisabledIds")]
        [HttpGet]
        public async Task<IActionResult> DisableIds()
        {
            try{
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                List<OwnerdetailsResponse> response = new List<OwnerdetailsResponse>();
                response = await ad.disableduserlist(filter);
                if (response == null) throw new CustomException("No data Found");
                return Ok(response);
            }catch (Exception ex){
                return Ok(ex.Message);
            }

        }
        [Route("DisableId/{id?}")]
        [HttpGet]
        public async Task<IActionResult> DisableId(int? id)
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
        public async Task<IActionResult> GetdetailsbyId(int? id)
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
        public async Task<IActionResult> Updatedetails([FromBody] ModifyRequest request)
        {
            try
            {
                OwnerdetailsAdapter ad = new OwnerdetailsAdapter(Shoppingmapper, dbconnection);
                OwnerdetailsResponse response = new OwnerdetailsResponse();
                if(request.UserId!=null) response = await ad.updatedetailsbyid(request, filter);
                else throw new CustomException("Mention User Id !!");
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
