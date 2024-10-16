using System.ComponentModel.DataAnnotations;

namespace Microservices.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]    // we use this things for the entity reqirement that comes in the DataAnnotations 
        public int CouponId { get; set; }
        [Required]
        public string CouponCode    { get;set; }
        [Required]  
        public double DiscountAmount { get; set; }

        public int MinAmount { get; set; }  //this entity is for check how much discount they are 
                                            //in the range to give them the coupon code 
        public DateTime LastUpdated { get; set; }
    }
}
