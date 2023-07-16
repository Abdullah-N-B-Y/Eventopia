using Eventopia.Core.Common;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Common;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Service;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Drawing;

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
		builder.Services.AddScoped<IUserRepository, UserRepository>();
		builder.Services.AddScoped<IUserService, UserService>();


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

