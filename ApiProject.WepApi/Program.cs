using ApiProject.WepApi.Context;
using ApiProject.WepApi.Entities;
using ApiProject.WepApi.ValidationRules;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApiContext>();

var assembly = Assembly.GetExecutingAssembly();

//foreach (var type in assembly.GetTypes())
//{
//	var interfaces = type.GetInterfaces();

//	foreach (var iface in interfaces)
//	{
//		// Yaln?z IValidator<T> tipini ?lav? edirik
//		if (iface.IsGenericType && iface.GetGenericTypeDefinition() == typeof(IValidator<>))
//		{
//			builder.Services.AddScoped(iface, type);
//		}
//	}
//}

builder.Services.AddScoped<IValidator<Product>,ProductValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
