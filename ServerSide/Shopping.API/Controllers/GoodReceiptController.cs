using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper Shoppingmapper;
        private readonly AppDbContext dbconnection;
        private IConfiguration _config;
    }
}
