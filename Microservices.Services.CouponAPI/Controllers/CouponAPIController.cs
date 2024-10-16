using AutoMapper;
using Azure;
using Microservices.Services.CouponAPI.Data;
using Microservices.Services.CouponAPI.Models;
using Microservices.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Microservices.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db; //
        private ResponseDto _response;
        private IMapper _mapper; //here we are using the service that we created over the program.cs

        public CouponAPIController(AppDbContext db , IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        [HttpGet]
        public ResponseDto Get()
        {

            try
            {
                IEnumerable<Coupon> obj= _db.Coupons.ToList();
                 _response.Result = _mapper.Map<IEnumerable<CouponDto>>(obj);
            }
            catch(Exception ex) {
                _response.IsSucess = false;
                _response.Message = ex.Message;
            }
            return _response;
            
        }
        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {

            try
            {
                Coupon obj = _db.Coupons.First(s => s.CouponId == id);
                //here are some line of code that has what to return here like DTOs
                //CouponDto dto = new CouponDto();
                //{ 
                //dto.CouponId = obj.CouponId;
                //dto.CouponCode = obj.CouponCode;
                //dto.DiscountAmount = obj.DiscountAmount;
                //dto.MinAmount = obj.MinAmount;
                //};
                //_response.Result = dto;
                //from here we are using dto to be return in the case of response 
                //we have  to migrate this because it is going to be the complex at any 
                //end point that why we use auto mapper thats there MappingConfig.cs

                _response.Result = _mapper.Map<CouponDto>(obj); 
                //here the automapper automatically convert the source to dastination 
                //keep going you are there .
            }
            catch(Exception ex) {
                _response.IsSucess = false;
                _response.Message = ex.Message;

            }
            return _response;

        }
        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)
        {

            try
            {
                Coupon obj = _db.Coupons.First(s => s.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message;

            }
            return _response;

        }
        [HttpPost]
      
        public ResponseDto Post([FromBody]  CouponDto couponDto)
        {

            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message;

            }
            return _response;

        }
        [HttpPut]
        public ResponseDto put([FromBody] CouponDto couponDto)
        {

            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message;

            }
            return _response;

        }

        [HttpDelete]
        public ResponseDto delete(int id)
        {

            try
            {
                Coupon obj = _db.Coupons.First(s => s.CouponId ==id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                

            }
            catch (Exception ex)
            {
                _response.IsSucess = false;
                _response.Message = ex.Message;

            }
            return _response;

        }
    }
}
