using Shopping.Common.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Shopping.DataLayer.Models;
using Shopping.Common.Responses;

namespace Shopping.DataLayer.AutoMapperStructure
{
    public class Automap : Profile
    {
        public Automap()
        {
            CreateMap<AdddetailsRequest, Ownerdetails>();
            CreateMap<Ownerdetails, OwnerdetailsResponse>();
        }
       
    }
}
