using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    [Route("api/GoodReceipt")]
    public class GoodReceiptController : Controller
    {
        private string filter = null;
        private readonly IMapper custommapper;
        private readonly AppDbContext dbconnection;
        private string _config;
        public GoodReceiptController(IMapper mapper, AppDbContext conn, IConfiguration configuration)
        {
            custommapper = mapper;
            this.dbconnection = conn;
            _config = configuration["StoreLogoFilePath"];
        }
        [Route("AddRecept")]
        [HttpPost]
        public async Task<IActionResult> AddGoodReceipt([FromBody] List<GoodReceiptRequest> requests)
        {
            Random rnd = new Random();
            var number = rnd.Next();
            List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
            try
            {
                foreach (GoodReceiptRequest request in requests) {
                    request.BillNumber = number.ToString();                  
                    GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                    if (request.ProductdetailProductId == null) { response.Add(new GoodReceiptResponse() { Sucess = false }); continue; }
                    if (request.OwnerdetailUserId == null) { response.Add(new GoodReceiptResponse() { Sucess = false }); continue; }
                    if (request.CustomerName==null) { response.Add(new GoodReceiptResponse() { Sucess = false }); continue; }
                    response.Add( await ad.savedetails(request, filter));
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("UpdateReceeptbyReceiptid")]
        [HttpPost]
        public async Task<IActionResult> editreceptbyid([FromBody] GoodReceiptRequest request)
        {
            try
            {
                GoodReceiptResponse response = new GoodReceiptResponse();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if (request.Grnumber==null) throw new CustomException("Recept Id is not mention");
                response= await ad.updatedetailsbyGrnmber(request, filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("UpdateCustomerNametbyBillnumber")]
        [HttpPost]
        public async Task<IActionResult> UpdateCustomerNamebybillnumber([FromBody] GoodReceiptRequest request)
        {
            try
            {
                List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if (request.BillNumber == null) throw new CustomException("Bill Number is not mention");
                if(request.CustomerName ==null) throw new CustomException("Customer Name is not mention");
                response=await ad.updatecustomernamebyGrnmber(request, filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("Selectbygrnumber/{gr?}")]
        [HttpGet]
        public async Task<IActionResult> Selectbygrnumber(int? gr)
        {
            try
            {
                GoodReceiptResponse response = new GoodReceiptResponse();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if (gr!=null) response = await ad.getdetailbyGrnumber(gr, filter); 
                else throw new CustomException("Good Receipt Number is not mention");        
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("Selectbybillnumber/{bill?}")]
        [HttpGet]
        public async Task<IActionResult> Selectbybillnumber(string bill)
        {
            try
            {
                List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if (bill != null) response=await ad.getdetailbyBillnumber(bill, filter);
                else throw new CustomException("Bill Number is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("SelectbyProductid/{proid?}/{Userid?}")]
        [HttpGet]
        public async Task<IActionResult> SelectbyProductId(int? proid, int? Userid)
        {
            try
            {
                List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if (proid != null && Userid != null) response = await ad.getdetailsbyProductid(proid, Userid, filter);
                else throw new CustomException("Product Id and User ID is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [Route("SelectbyUserid/{Userid?}")]
        [HttpGet]
        public async Task<IActionResult> SelectbyUserId(int? Userid)
        {
            try
            {
                List<GoodReceiptResponse> response = new List<GoodReceiptResponse>();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if ( Userid != null) response = await ad.getdetailsbyUserId(Userid, filter);
                else throw new CustomException(" User ID is not mention");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
