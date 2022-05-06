using Microsoft.EntityFrameworkCore;
using SystemSale.Data;
using SystemSale.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SystemSaleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SystemSaleContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<VendaService>();
builder.Services.AddScoped<ProdutoService>();
builder.Services.AddScoped<LoginService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
