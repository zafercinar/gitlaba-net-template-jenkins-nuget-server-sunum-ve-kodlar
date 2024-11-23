using ZACx.Templates.WebApiProject.Business.Extensions;
using ZACx.Templates.WebApiProject.DataAccess.Extensions;
using ZACx.Templates.WebApiProject.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiRegistration(hostBuilder: builder.Host); //API Layer => Add IoC(DI) Services Collection
builder.Services.AddDataAccessRegistration(); //DataAcces Layer => Add IoC(DI) Services Collection
builder.Services.AddBusinessRegistration();//Business Layer => Add IoC(DI) Services Collection

var app = builder.Build();// => BuildServiceProvider()

app.UseApiRegistration();//Api Layer => Use Middleware Settings

app.Run(); // Application Start
