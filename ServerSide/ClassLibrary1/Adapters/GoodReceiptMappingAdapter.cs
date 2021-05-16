using AutoMapper;
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
using Microsoft.EntityFrameworkCore;
using Shopping.BLayer.Interfaces;

namespace Shopping.BLayer.Adapters
{
    public class GoodReceiptMappingAdapter : IGoodReceiptMapping
    {
        private GoodReceiptMapping goodReceiptMapping;
        private List<GoodReceiptMapping> goodReceiptMappings;
        private IMapper custommapper;
        private readonly AppDbContext dbconnection;
        public GoodReceiptMappingAdapter(IMapper Shoppingmapper, AppDbContext conn)
        {
            custommapper = Shoppingmapper;
            this.dbconnection = conn;
        }
        public async Task<GoodReceiptMappingResponse> save(GoodReceiptMappingRequest data)
        {
            GoodReceiptMappingResponse response = new GoodReceiptMappingResponse();
            var result = await(from a in dbconnection.Ownerdetails
                               where a.UserId == data.UserId && a.IsActive == true && a.IsDelete == false
                               select a).FirstOrDefaultAsync();
            if (result == null) { throw new CustomException("User Id Not Found !"); }
            goodReceiptMappings = new List<GoodReceiptMapping>();

            goodReceiptMappings= await (from a in dbconnection.GoodReceiptMapping
                                        where a.UserId == data.UserId && a.IsActive == true && a.IsDelete == false
                                        select a).ToListAsync();
            foreach(GoodReceiptMapping goodReceiptMapping in goodReceiptMappings)
            {
                goodReceiptMapping.IsActive = false;
                goodReceiptMapping.IsDelete = true;
                goodReceiptMapping.ModifyOn = DateTime.UtcNow;
                if( await dbconnection.SaveChangesAsync() < 0) { throw new CustomException("Internal Server Error !"); }
            }

            goodReceiptMapping = new GoodReceiptMapping();
            goodReceiptMapping.CreatedOn = DateTime.UtcNow;
            goodReceiptMapping.header = data.header;
            goodReceiptMapping.IsActive = true;
            goodReceiptMapping.IsDelete = false;
            goodReceiptMapping.UserId = data.UserId;
            goodReceiptMapping.logo = data.logo;
            dbconnection.GoodReceiptMapping.Add(goodReceiptMapping);
            var row = await dbconnection.SaveChangesAsync();
            response = custommapper.Map<GoodReceiptMapping, GoodReceiptMappingResponse>(goodReceiptMapping);
            response.Sucess = row > 0;
            return response;
        }
    }
}
