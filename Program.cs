﻿using WebApi.Authorization;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    services.AddCors();
    services.AddControllers();

    // configure DI for application services
    services.AddSingleton<IUserService, UserService>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    app.UseHttpsRedirection();

    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // custom basic auth middleware
    app.UseMiddleware<BasicAuthMiddleware>();

    app.MapControllers();
}

app.Run();