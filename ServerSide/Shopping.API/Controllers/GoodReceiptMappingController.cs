using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.BLayer.Adapters;
using Shopping.Common.Exceptions;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.Common;
using Shopping.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Shopping.API.Controllers
{
    [Route("api/GoodReceiptMapping")]
    public class GoodReceiptMappingController : Controller
    {
        private readonly IMapper Shoppingmapper;
        private readonly AppDbContext dbconnection;
        private string _config;
       public GoodReceiptMappingController(IMapper mapper, AppDbContext conn, IConfiguration configuration)
        {
            Shoppingmapper = mapper;
            this.dbconnection = conn;
            _config = configuration["StoreLogoFilePath"];
        }

        [Route("AddMapping")]
        [HttpPost]
        public async Task<IActionResult> AddMapping([FromForm] GoodReceiptMappingRequest request)
        {
            try
            {
                GoodReceiptMappingAdapter ad = new GoodReceiptMappingAdapter(Shoppingmapper, dbconnection);
                GoodReceiptMappingResponse response = new GoodReceiptMappingResponse();
                if (request.UserId != null)
                {
                    var fileurl = new MultiFileUpload(_config);
                    KeyValuePair<string, bool> url = await fileurl.fileUpload(request.ImageContent);
                    if (url.Value == true) { request.logo = url.Key; }
                    else { request.logo = "Some Error Occur During Uplaoad Image"; }
                    response = await ad.save(request);
                }
                else throw new CustomException("Mention User id !");
                if (response.Sucess == false) throw new CustomException("Internal Server Error !");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
