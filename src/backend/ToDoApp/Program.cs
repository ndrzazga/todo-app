using Application.UseCases.Items;
using Infrastructure.Repositories.Implementation.Items;
using InputPort.UseCases.Items;
using OutputPort.Repositories.Items;
using System.Data;
using System.Data.SqlClient;
using ToDoApp.Controllers;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI use cases
builder.Services.AddScoped<IAddItemUseCase, AddItemUseCase>();
builder.Services.AddScoped<IDeleteItemUseCase, DeleteItemUseCase>();
builder.Services.AddScoped<IGetAllItemsUseCase, GetAllItemsUseCase>();
builder.Services.AddScoped<IGetItemByIdUseCase, GetItemByIdUseCase>();
builder.Services.AddScoped<IUpdateItemUseCase, UpdateItemUseCase>();

//DI repositories
builder.Services.AddScoped<IAddItemRepository, AddItemRepository>();
builder.Services.AddScoped<IDeleteItemRepository, DeleteItemRepository>();
builder.Services.AddScoped<IGetAllItemsRepository, GetAllItemsRepository>();
builder.Services.AddScoped<IGetItemByIdRepository, GetItemByIdRepository>();
builder.Services.AddScoped<IUpdateItemRepository, UpdateItemRepository>();

//DI SQL connection
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(builder.Configuration.GetConnectionString("ToDoAppConnectionString")));

//allow cors
builder.Services.AddCors(p => p.AddPolicy("ToDoApp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

WebApplication app = builder.Build();

app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//use cors configuration
app.UseCors("ToDoApp");

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

// Register endpoints in ItemsEndpoints.cs
app.MapItemsEndpoints();

// Register errors handle
app.MapErrorEndpoints();

app.Run();
