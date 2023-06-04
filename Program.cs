using cmTest.Services;
using cmTest.Services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//scopes
builder.Services.AddScoped<IBasketballRetrievalService, BasketballRetrievalService>();
builder.Services.AddScoped<ISmsService, SmsService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//keys
var CmProductToken = builder.Configuration["CM:ProductToken"];
var SportsApiKey = builder.Configuration["SportsApi:ApiKey"];


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
