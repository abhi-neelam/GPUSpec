using GPUSpecServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "GPUSpec API",
        Description = "An ASP.NET Core Web API for querying gpu specification information",
        TermsOfService = new Uri("https://example.com/terms")
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

if (builder.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
    app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // TODO - setup proper routing for production
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
