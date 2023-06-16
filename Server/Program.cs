var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors();
builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();


app.UseCors(o => o.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader());

app.Run();
