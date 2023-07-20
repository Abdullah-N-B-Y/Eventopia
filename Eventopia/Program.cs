using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Common;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Service;


namespace Eventopia;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

		builder.Services.AddScoped<IDbContext, DbContext>();
		builder.Services.AddScoped<IRepository<Booking>, BookingRepository>();
		builder.Services.AddScoped<IService<Booking>, BookingService>();
		builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
		builder.Services.AddScoped<IService<Category>, CategoryService>();
		builder.Services.AddScoped<IRepository<Page>, PageRepository>();
		builder.Services.AddScoped<IService<Page>, PageService>();
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IAdminRepository, AdminRepository>();
		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IAdminService, AdminService>();

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

        app.Run();
    }
}

