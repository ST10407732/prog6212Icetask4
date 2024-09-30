using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PROG2BIceTask4.Data;
using PROG2BIceTask4.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PROG2BICETask4>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CLDV_ICE_TASKContext") ?? throw new InvalidOperationException("Connection string 'CLDV_ICE_TASKContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    IceTask1.Models.Data.Initialize(services);
}

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
