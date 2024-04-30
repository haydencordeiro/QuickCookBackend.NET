using Microsoft.EntityFrameworkCore;
using Recipe_API.Model;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

// Add services to the container.
builder.Services.AddDbContext<RecipeContext>(options =>
     options.UseSqlServer("Server=HAYDEN\\SQLEXPRESS;Database=RecipesDB;TrustServerCertificate=True;Trusted_Connection=True;MultipleActiveResultSets=true;"));

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

//app.UseHttpsRedirection();
app.UseCors("myAppCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
