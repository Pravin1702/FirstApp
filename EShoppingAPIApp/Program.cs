using EShoppingAPIApp.Models;
using EShoppingAPIApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<UserRepo>();
builder.Services.AddScoped<IRepo<int, Products>, ProductsRepo>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyOrigin().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();
