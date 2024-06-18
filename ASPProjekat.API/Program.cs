using ASPProjekat.API;
using ASPProjekat.DataAccess;
using System.Data;
using Microsoft.Data.SqlClient;
using ASPProjekat.ApplicationLayer.UseCase;
using ASPProjekat.Implementation;
using ASPProjekat.Implementation.Validators;
using ASPProjekat.ApplicationLayer.Commands;
using ASPProjekat.Implementation.UseCases.Commands;
using ASPProjekat.Implementation.Logging;
using ASPProjekat.ApplicationLayer.Queries;
using ASPProjekat.Implementation.UseCases.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();

builder.Configuration.Bind(settings);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ASPContext>(x => new ASPContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));

builder.Services.AddTransient<CreateBookValidator>();
builder.Services.AddTransient<CreateEditionValidator>();
builder.Services.AddTransient<CreateOrderValidator>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<UpdateBookValidator>();
builder.Services.AddTransient<UpdateEditionValidator>();




builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IUserUseCaseProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<ASPContext>();

    return new AuthorizationUserProvider(authHeader, context);
});
builder.Services.AddTransient<IUserUseCase>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedUser();
    }

    return x.GetService<IUserUseCaseProvider>().getUser();
});

builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IRegisterUser, EfRegisterUser>();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
builder.Services.AddTransient<IGetBooks, EfGetBooks>();
builder.Services.AddTransient<IGetUsers, EfGetUsers>();
builder.Services.AddTransient<IGetUserOrders, EfGetUserOrders>();
builder.Services.AddTransient<ICheckBookAvailability, EfCheckBookAvailability>();
builder.Services.AddTransient<ICreateBook, EfCreateBook>();
builder.Services.AddTransient<ICreateEdition, EfCreateEdition>();
builder.Services.AddTransient<ICreateOrder, EfCreateOrder>();
builder.Services.AddTransient<IUpdateBook, EfUpdateBook>();
builder.Services.AddTransient<IUpdateEdition, EfUpdateEdition>();

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
