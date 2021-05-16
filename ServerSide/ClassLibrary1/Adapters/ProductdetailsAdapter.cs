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
        private Productdetails productdetails;
        private List<Productdetails> listproductdetails;
        private Ownerdetails ownerdetails;
        private IMapper custommapper;
        private readonly AppDbContext dbconnection;
        public ProductdetailsAdapter(IMapper Shoppingmapper, AppDbContext conn)
        {
            custommapper = Shoppingmapper;
            this.dbconnection = conn;
        }
        public async Task<ProductdetailsResponse> activeproductbyid(int id, string filter)
        {
            productdetails = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            productdetails = await (from a in dbconnection.Productdetails where a.ProductId==id && a.IsDelete == true select a).FirstOrDefaultAsync();
            if (productdetails != null)
            {
                productdetails.IsActive = true;
                productdetails.IsDelete = false;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Productdetails, ProductdetailsResponse>(productdetails);
                response.Sucess = row > 0;
            }
            else throw new CustomException("User Id is Not Valid");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> activeproductlist(string filter)
        {
            listproductdetails = new List<Productdetails>();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            listproductdetails = await(from a in dbconnection.Productdetails where a.IsActive == true select a).ToListAsync();
            if (listproductdetails.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(listproductdetails);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<ProductdetailsResponse> disableproductbyid(int id, string filter)
        {
            productdetails = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            productdetails = await(from a in dbconnection.Productdetails select a).FirstOrDefaultAsync();
            if (productdetails != null)
            {
                productdetails.IsActive = false;
                productdetails.IsDelete = true;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Productdetails, ProductdetailsResponse>(productdetails);
                response.Sucess = row > 0;
            }
            else throw new CustomException("User Id is Not Valid");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> disabledproductlist(string filter)
        {
            productdetails = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await(from a in dbconnection.Productdetails where a.IsDelete == true select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> getdetailbyUserId(int id, string filter)
        {
            var result = await (from a in dbconnection.Ownerdetails
                                where a.UserId == id && a.IsActive == true && a.IsDelete == false
                                select a).FirstOrDefaultAsync();
            if (result == null) { throw new CustomException("User Id Not Found !"); }

            listproductdetails = new List<Productdetails>();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            listproductdetails = await(from a in dbconnection.Productdetails where a.OwnerdetailUserId==id select a).ToListAsync();
            if (listproductdetails.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(listproductdetails);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> getdetailbyrating(int Rating, string filter)
        {
            listproductdetails = new List<Productdetails>();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            listproductdetails = await(from a in dbconnection.Productdetails where a.Rating == Rating select a).ToListAsync();
            if (listproductdetails.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(listproductdetails);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<ProductdetailsResponse> saveproduct(AddProductdetailRequest data, string filter)
        {
            var result = await (from a in dbconnection.Ownerdetails
                                where a.UserId == data.OwnerdetailUserId && a.IsActive == true && a.IsDelete == false
                                select a).FirstOrDefaultAsync();
            if (result == null ) { throw new CustomException("User Id Not Found !"); }
            
            ownerdetails = new Ownerdetails();
            ownerdetails.UserId = data.OwnerdetailUserId;
            ownerdetails.Productdetails = new List<Productdetails> { productdetails };

            productdetails = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            productdetails = custommapper.Map<AddProductdetailRequest, Productdetails>(data);
            productdetails.CreatedOn = DateTime.UtcNow;
            productdetails.ModifyOn = DateTime.UtcNow;
            productdetails.IsActive = true;
            productdetails.IsDelete = false;
            dbconnection.Productdetails.Add(productdetails);

            var row = await dbconnection.SaveChangesAsync();
            response = custommapper.Map<Productdetails, ProductdetailsResponse>(productdetails);
            response.Sucess = row > 0;
            return response;
        }

        public async Task<ProductdetailsResponse> updatedetailsbyid(AddProductdetailRequest data, string filter)
        {
            var result = await (from a in dbconnection.Ownerdetails
                                where a.UserId == data.OwnerdetailUserId && a.IsActive == true && a.IsDelete == false
                                select a).FirstOrDefaultAsync();
            if (result == null) { throw new CustomException("User Id Not Found !"); }

            productdetails = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            productdetails = await (from a in dbconnection.Productdetails where a.ProductId == data.ProductId && a.OwnerdetailUserId == data.OwnerdetailUserId select a).FirstOrDefaultAsync();
            if (productdetails != null)
            {
                productdetails.ProductName = data.ProductName;
                productdetails.Quantity =data.Quantity;
                productdetails.Price = data.Price;
                productdetails.ImageUrl = data.ImageUrl;
                productdetails.ModifyOn = DateTime.UtcNow;
                productdetails.Rating = data.Rating;
                productdetails.IsActive = true;
                productdetails.IsDelete = false;
                var row = await dbconnection.SaveChangesAsync();
                response = custommapper.Map<Productdetails, ProductdetailsResponse>(productdetails);
                response.Sucess = row > 0;
            }
            else throw new CustomException("detail !");
            return response;
        }

        public async Task<ProductdetailsResponse> getdetailbyProductId(int id, string filter)
        {
            productdetails = new Productdetails();
            ProductdetailsResponse response = new ProductdetailsResponse();
            productdetails = await (from a in dbconnection.Productdetails where a.ProductId == id select a).FirstOrDefaultAsync();
            if (productdetails != null) response = custommapper.Map<ProductdetailsResponse>(productdetails);
            else throw new CustomException("data Not Found !");
            return response;
        }

        public async Task<List<ProductdetailsResponse>> getdetailbyProductName(string name, string filter)
        {
            productdetails = new Productdetails();
            List<ProductdetailsResponse> response = new List<ProductdetailsResponse>();
            var data = await (from a in dbconnection.Productdetails where a.ProductName == name select a).ToListAsync();
            if (data.Count != 0) response = custommapper.Map<List<ProductdetailsResponse>>(data);
            else throw new CustomException("data Not Found !");
            return response;
        }

    }
}
