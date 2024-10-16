using AutoMapper;
using Microservices.Services.CouponAPI;
using Microservices.Services.CouponAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//this is the main file where we add services and configure the pipe line.
//here we use the service of db context class to communicate with the database.
//we will define the connection string inside appsetting.json for security perpose and we will
//use the name of the connection strin like DefaultConnection in this case 
builder.Services.AddDbContext<AppDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
     });

//here we mapped out mapping config file and added as singleton
//this service we use for only the dtos 

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
//singleton, the same instance is used every time it's requested by the application.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
ApplyMigration();    //here i have register inside the pipe line 

app.Run();

// ApplyMigration() i have created this method to check is there any pending migration ?
//if yes this method automatically migrate to the database  good keep going 
//i want to check in the AppDbContext is there any pending migration 
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();

        }
    }
}