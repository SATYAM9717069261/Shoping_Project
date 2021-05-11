using AutoMapper;
using Shopping.BLayer.Interfaces;
using Shopping.Common.Exceptions;
using Shopping.Common.Requests;
using Shopping.Common.Responses;
using Shopping.DataLayer.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Shopping.BLayer.Adapters
{
    public class ProductdetailsAdapter : IProductdetails
    {
        private Productdetails details;
        private IMapper custommapper;
        private readonly AppDbContext dbconnection;
        public ProductdetailsAdapter(IMapper Shoppingmapper, AppDbContext conn)
        {
            custommapper = Shoppingmapper;
            this.dbconnection = conn;
        }
        public async Task<ProductdetailsResponse> activeproductbyid(int id, string filter)
        {
            details = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            details = await (from a in dbconnection.Productdetails where a.ProductId==id select a).FirstOrDefaultAsync();
            if (details != null)
            {
                details.IsActive = true;
                details.IsDelete = false;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Productdetails, ProductdetailsResponse>(details);
                response.Sucess = row > 0;
            }
            else throw new CustomException("User Id is Not Valid");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> activeproductlist(string filter)
        {
            details = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await(from a in dbconnection.Productdetails where a.IsActive == true select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<ProductdetailsResponse> disableproductbyid(int id, string filter)
        {
            details = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            details = await(from a in dbconnection.Productdetails where a.UserId == id select a).FirstOrDefaultAsync();
            if (details != null)
            {
                details.IsActive = false;
                details.IsDelete = true;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Productdetails, ProductdetailsResponse>(details);
                response.Sucess = row > 0;
            }
            else throw new CustomException("User Id is Not Valid");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> disabledproductlist(string filter)
        {
            details = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await(from a in dbconnection.Productdetails where a.IsDelete == true select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> getdetailbyUserId(int id, string filter)
        {
            details = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await(from a in dbconnection.Productdetails where a.UserId == id select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> getdetailbyrating(int Rating, string filter)
        {
            details = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await(from a in dbconnection.Productdetails where a.Rating == Rating select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<ProductdetailsResponse> saveproduct(AddProductdetailRequest data, string filter)
        {
            details = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            details = custommapper.Map<AddProductdetailRequest, Productdetails>(data);
            details.CreatedOn = DateTime.UtcNow;
            details.ModifyOn = DateTime.UtcNow;
            details.IsActive = true;
            details.IsDelete = false;
            dbconnection.Productdetails.Add(details);
            var row = await dbconnection.SaveChangesAsync();
            response = custommapper.Map<Productdetails, ProductdetailsResponse>(details);
            response.Sucess = row > 0;
            return response;
        }

        public async Task<ProductdetailsResponse> updatedetailsbyid(AddProductdetailRequest data, string filter)
        {
            details = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            details = await (from a in dbconnection.Productdetails where a.ProductId == data.ProductId && a.UserId==data.UserId  select a).FirstOrDefaultAsync();
            if (details != null)
            {
                details.ProductName = data.ProductName;
                details.Quantity =(long)data.Quantity;
                details.Price = data.Price;
                details.ImageUrl = data.ImageUrl;
                details.ModifyOn = DateTime.UtcNow;
                details.IsActive = true;
                details.IsDelete = false;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Productdetails, ProductdetailsResponse>(details);
                response.Sucess = row > 0;
            }
            else throw new CustomException("detail !");
            return response;
        }

        public async Task<ProductdetailsResponse> getdetailbyProductId(int id, string filter)
        {
            details = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            var data = await (from a in dbconnection.Productdetails where a.ProductId == id select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<ProductdetailsResponse>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> getdetailbyProductName(string name, string filter)
        {
            details = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await (from a in dbconnection.Productdetails where a.ProductName == name select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        
    }
}
