using Autofac.Core;
using HotChocolate;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using UserManagement_Application.Services;
using UserManagement_Domain.Interfaces;
using UserManagement_Infustracture.Extension;
using UserManagement_Infustracture.GraphQl;
using UserManagement_Infustracture.Implementation;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IUserService, UserService>();
//builder.Services.AddSingleton<IUserRepository, IUserRepository>();
builder.Services.AddPresistence(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();

    // Redirect to GraphQL Playground
    
}

app.UseRouting();

var options = new RewriteOptions()
        .AddRedirect("^$", "playground/"); // Redirect root to /playground/

app.UseRewriter(options);


app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/api",
    Path = "/playground"

});


app.MapGraphQL("/api");

app.UseAuthorization();

app.MapControllers();

app.Run();
