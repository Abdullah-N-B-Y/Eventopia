using Eventopia.Core.Common;
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Common;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
        builder.Services.AddScoped<IRepository<Message>, MessageRepository>();
        builder.Services.AddScoped<IService<Message>, MessageService>();
        builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
		builder.Services.AddScoped<IService<Category>, CategoryService>();
		builder.Services.AddScoped<IRepository<Page>, PageRepository>();
		builder.Services.AddScoped<IService<Page>, PageService>();
		builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IAdminService, AdminService>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IAuthRepository, AuthRepository>();
		builder.Services.AddScoped<IAuthService, AuthService>();
		builder.Services.AddScoped<IUserService, UserService>();
		builder.Services.AddScoped<IAdminService, AdminService>();
		builder.Services.AddScoped<IAuthRepository, AuthRepository>();
		builder.Services.AddScoped<IAuthService, AuthService>();




		builder.Services.AddAuthentication(opt => {
			opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(options => {
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
			};
		});

		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("AdminOnly", policy => { policy.RequireClaim("RoleId", "1");});
			options.AddPolicy("AdminUserOnly", policy => { policy.RequireClaim("RoleId", "2"); });
		});
		// EX: [Authorize(Policy = "AdminOnly")] // Enforce the custom policy for role-based authorization

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
		app.UseAuthentication();
		app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}

