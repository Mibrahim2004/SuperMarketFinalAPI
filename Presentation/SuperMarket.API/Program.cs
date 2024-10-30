using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using SuperMarket.Application.Validations.UserValidators;
using SuperMarket.Infrastructure.Registrations;
using SuperMarket.Persistence.Registrations;
using System.Collections.ObjectModel;
using System.Data;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using SuperMarket.Application.AutoMappers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers() .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateUserValidator>());
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureService();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));
Logger? log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/mylog-{Date}.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("FinalProject"), sinkOptions: new MSSqlServerSinkOptions
    {
        TableName = "CSWALog",
        AutoCreateSqlTable = true
    },
    null, null, LogEventLevel.Warning, null,
    columnOptions: new ColumnOptions
    {
        AdditionalColumns = new Collection<SqlColumn>
        {
            new SqlColumn(columnName:"User_Name",SqlDbType.NVarChar)
        }
    },
    null, null
    )
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();
Log.Logger = log;
builder.Host.UseSerilog(log);

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
