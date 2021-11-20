using MediatR;
using SavvyyLibrary.Repository;
using SavvyyLibrary.Repository.EF;
using SavvyyLibrary.Service.Dto;
using SavvyyLibrary.Service.Library;
using SavvyyLibrary.ServiceHandler.Library;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddMediatR(typeof(CreateBookService).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(EditBookService).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(DeleteBookService).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(GetBookService).GetTypeInfo().Assembly);

builder.Services.AddTransient(typeof(IRequestHandler<CreateBookService, int>), typeof(CreateBookServiceHandler));
builder.Services.AddTransient(typeof(IRequestHandler<EditBookService, BookDto>), typeof(EditBookServiceHandler));
builder.Services.AddTransient(typeof(IRequestHandler<GetBookService, BookDto>), typeof(GetBookServiceHandler));
builder.Services.AddTransient(typeof(IRequestHandler<DeleteBookService, Unit>), typeof(DeleteBookServiceHandler));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//// Attribute routing.
//config.MapHttpAttributeRoutes();

//// Convention-based routing.
//config.Routes.MapHttpRoute(
//    name: "DefaultApi",
//    routeTemplate: "api/{controller}/{id}",
//    defaults: new { id = RouteParameter.Optional }
//);

app.MapControllers();

app.Run();
