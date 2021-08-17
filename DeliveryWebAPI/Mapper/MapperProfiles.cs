using AutoMapper;
using DeliveryWebAPI.Domain.Models;
using DeliveryWebAPI.Models.FrontMappedModels;
using DeliveryWebAPI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryWebAPI.Mapper
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            
            //CreateMap<User, UserRegistrationViewModel>();
            CreateMap<User, UserModel>();
            CreateMap<User, AdminLoginModel>();
            CreateMap<User, PersonalRegistrationModel>();
            CreateMap<StorageProductModel, StorageProduct>();
            CreateMap<Product, ProductModel>();


        }
    }
}
