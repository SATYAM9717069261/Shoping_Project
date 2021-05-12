using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.BLayer.Adapters;
using Shopping.Common.Exceptions;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.API.Controllers
{
    [Route("api/Product")]
    public class ProductdetailsController : Controller
    {
        private string filter = null;
        private readonly IMapper Shoppingmapper;
        private readonly AppDbContext dbconnection;
        public ProductdetailsController(IMapper mapper, AppDbContext conn)
        {
            Shoppingmapper = mapper;
            this.dbconnection = conn;
        }

        [Route("AddProduct")]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductdetailRequest request)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                ProductdetailsResponse response = new ProductdetailsResponse();
                if(request.OwnerdetailUserId !=null) response = await ad.saveproduct(request, filter);
                else throw new CustomException("Mention User id !");
                if (response.Sucess == false) throw new CustomException("Internal Server Error !");
                return Ok(response);
            }
            catch (Exception ex)
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
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                ProductdetailsResponse response = new ProductdetailsResponse();
                if (id != null) response = await ad.activeproductbyid((int)id, filter);
                else throw new CustomException("Product Id is not mention");
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
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
                response = await ad.activeproductlist(filter);
                if (response == null) throw new CustomException("No data Found");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("DisabledIds")]
        [HttpGet]
        public async Task<IActionResult> DisableIds()
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
                response = await ad.disabledproductlist(filter);
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
        public async Task<IActionResult> DisableId(int? id)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                ProductdetailsResponse response = new ProductdetailsResponse();
                if (id != null) response = await ad.disableproductbyid((int)id, filter);
                else throw new CustomException("User Id is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [Route("GetdetailsbyProductId/{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetdetailsbyProductId(int? id)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                ProductdetailsResponse response = new ProductdetailsResponse();
                if (id != null) response = await ad.getdetailbyProductId((int)id, filter);
                else throw new CustomException("Product Id is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
        [Route("GetdetailsbyUserId/{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetdetailsbyUserId(int? id)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
                if (id != null) response = await ad.getdetailbyUserId((int)id, filter);
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
        public async Task<IActionResult> Updatedetails([FromBody] AddProductdetailRequest request)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                ProductdetailsResponse response = new ProductdetailsResponse();
                if (request.ProductId != null && request.OwnerdetailUserId != null ) response = await ad.updatedetailsbyid(request, filter);
                else throw new CustomException("Please Mention Product Id and User Id !!");
                if (response.Sucess == null) throw new CustomException("Internal Server Error");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [Route("GetdetailsbyProductRating/{rating?}")]
        [HttpGet]
        public async Task<IActionResult> GetdetailsbyProductrating(int? rating)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
                if (rating != null) response = await ad.getdetailbyrating((int)rating, filter);
                else throw new CustomException("Rating is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
        
        [Route("GetdetailsbyProductName/{name?}")]
        [HttpGet]
        public async Task<IActionResult> GetdetailsbyProductName(string name)
        {
            try
            {
                ProductdetailsAdapter ad = new ProductdetailsAdapter(Shoppingmapper, dbconnection);
                List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
                if (name != null) response = await ad.getdetailbyProductName(name, filter);
                else throw new CustomException("Product Name is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }



    }
}
