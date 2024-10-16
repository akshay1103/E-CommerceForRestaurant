using Microservices.Services.CouponAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.CouponAPI.Data
{
    //when we use entity framework core we have to use DbContext as a base class to perform the 
    //action of the entity framework
    public class AppDbContext : DbContext      //we need to configure DbContext in the program.cs file 

    {
        //here we the ctor to pass the values to the base class  --DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) 
        { 
        
        }
        public DbSet<Coupon> Coupons { get; set; }     //this Coupons is my data table name 

        //i have to over ride this method (OnModelCreating) to feed the values to the database cool!
        //for seeding data in table we use ModelBuilder to work with that 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "initial coupon",
                DiscountAmount = 5.00,
                MinAmount = 50

            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon
           {
                CouponId = 2,
                CouponCode = "second coupon",
                DiscountAmount =3.00,
                MinAmount = 70
            });
            //now run the pakage maneger console add-migration SeedCouponTables



        }

    }
}
