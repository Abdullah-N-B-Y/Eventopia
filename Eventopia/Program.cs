using Eventopia.API.Filters;
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

        builder.Services.AddControllers(options =>
		{
			options.Filters.Add<ErrorHandlingFilterAttribute>();
			options.Filters.Add<ValidateModelStateActionFilter>();
		});
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

        builder.Services.AddScoped<IRepository<Profile>, ProfileRepository>();
        builder.Services.AddScoped<IService<Profile>, ProfileService>();

        builder.Services.AddScoped<IRepository<Testimonial>, TestimonialRepository>();
        builder.Services.AddScoped<IService<Testimonial>, TestimonialService>();

		builder.Services.AddScoped<IRepository<ContactUsEntry>, ContactUsEntriesRepository>();
		builder.Services.AddScoped<IService<ContactUsEntry>, ContactUsEntriesService>();

		builder.Services.AddScoped<IEventRepository, EventRepository>();
        builder.Services.AddScoped<IEventService, EventService>();

        builder.Services.AddScoped<IAdminRepository, AdminRepository>();
        builder.Services.AddScoped<IAdminService, AdminService>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

		builder.Services.AddScoped<IAuthRepository, AuthRepository>();
		builder.Services.AddScoped<IAuthService, AuthService>();

		builder.Services.AddScoped<ICommentsRepository, CommentsRepository>();
		builder.Services.AddScoped<ICommentsService, CommentsService>();

        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IBookingService, BookingService>();

		builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
		builder.Services.AddScoped<ICategoryService, CategoryService>();

		builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
		builder.Services.AddScoped<IProfileService, ProfileService>();

		builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
		builder.Services.AddScoped<IPaymentService, PaymentService>();

		builder.Services.AddAuthentication(opt =>
		{
			opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidIssuer = builder.Configuration["AppSettings:Issuer"],
				ValidAudience = builder.Configuration["AppSettings:Audience"],
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:SecretKey"]))
			};
		});

		builder.Services.AddAuthorization(options =>
		{
			options.AddPolicy("AdminOnly", policy => { policy.RequireClaim("RoleId", "1"); });
			options.AddPolicy("AdminAndUserOnly", policy => { policy.RequireClaim("RoleId", "2", "1"); });
		});
		// EX: [Authorize(Policy = "AdminOnly")] // Enforce the custom policy for role-based authorization

		builder.Services.AddCors(options =>
		{
			options.AddPolicy("policy", builder =>
			{
				builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
			});
		});

		var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

		app.UseCors("policy");
		app.UseHttpsRedirection();
		app.UseAuthentication();
		app.UseAuthorization();
		app.MapControllers();

        app.Run();
    }
}

