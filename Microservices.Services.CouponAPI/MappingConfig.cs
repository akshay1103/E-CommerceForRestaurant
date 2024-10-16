using AutoMapper;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.Dto;
namespace Microservices.Services.CouponAPI
{
    public class MappingConfig//we are creating this class to return the dots with automaaper 
    {
        public static MapperConfiguration RegisterMaps()
        {
            // i have to register as a service inside the program.cs file check out there

            var mappingConfig = new MapperConfiguration(Config =>
            {
                Config.CreateMap<CouponDto,Coupon>();
                //inside the createMap method i have these option where you have to manage 
                //source destination i have create two here for vise-versa
                Config.CreateMap<Coupon, CouponDto>();

            });    
            return mappingConfig; //finally we are returing the mapping Config 


        }
    }
}

//MapperConfiguration defines and holds the mapping rules between types (CouponDto and Coupon).
//The CreateMap method defines how to map one object to another.
//Once set up, you return the mappingConfig so it can be used to create an IMapper instance, which will perform the actual mappings in your application.