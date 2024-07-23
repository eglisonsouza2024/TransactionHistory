using System.Text.Json.Serialization;
using TransactionHistory.Application.Extensions;
using TransactionHistory.Infra.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
