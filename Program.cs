using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using PharmacyWebApp.Controllers;
using PharmacyWebApp.Models;
using PharmacyWebApp.Interfaces;
using PharmacyWebApp.Models.HelperClasses;
using RedirectResult = System.Web.Http.Results.RedirectResult;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PharmacyDB>(option => 
    option.UseSqlite(builder.Configuration.GetConnectionString("PharmacyDBConncetion"))
    .UseLazyLoadingProxies());
builder.Services.AddScoped<PharmacyDB>();
builder.Services.AddTransient<IPartyHelper, PartyHelper>();
builder.Services.AddTransient<IPharmacyHelper, PharmacyHelper>();
builder.Services.AddTransient<IProductHelper, ProductHelper>();
builder.Services.AddTransient<IWarehouseHelper, WarehouseHelper>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "PharmacyWebApp",
        Version = "v1"
    });
});

//builder.WebHost.UseUrls($"https://localhost:7166/swagger");

var app = builder.Build();
//app.UsePathBase($"/swagger");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "PharmacyWebApp"); });
}
app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

/*app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Pharmacy}/{action=PharmacyPage}/{id?}");
});*/

app.UseEndpoints(e =>
{
    e.MapGet("/", async context =>
    {
        await Task.Factory.StartNew(()=> context.Response.Redirect("Pharmacy/PharmacyPage"));
    });

    //e.MapControllerRoute(
    //    name: "/",
    //    pattern: "{controller=Pharmacy}/{action=PharmacyPage}/{id?}");
});


/*app.MapControllerRoute(
    name: "",
    pattern: "{controller=Pharmacy}/{action=PharmacyPage}/{id?}");*/

app.Run();
