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

        [Route("UpdateReceept")]
        [HttpPost]
        public async Task<IActionResult> editreceptbyid([FromBody] GoodReceiptRequest request)
        {
            try
            {
                GoodReceiptResponse response = new GoodReceiptResponse();
                GoodRceiptAdapter ad = new GoodRceiptAdapter(custommapper, dbconnection);
                if (request.Grnumber==null) throw new CustomException("Recept Id is not mention");
                response= await ad.updatedetails(request, filter);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
