using Management.Infrastructure.Data;
using Management.Infrastructure.Repositories.Implementations;
using Management.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "management-spa",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                      });
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AccountingDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
builder.Services.AddScoped<IAccountingDocumentRepository, AccountingDocumentRepository>();

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
app.UseCors("management-spa");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
