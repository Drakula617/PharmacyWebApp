using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using PharmacyWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PharmacyDB>(option => 
    option.UseSqlite(builder.Configuration.GetConnectionString("PharmacyDBConncetion"))
    .UseLazyLoadingProxies());
builder.Services.AddScoped<PharmacyDB>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "PharmacyWebApp",
        Version = "v1"
    });
});
var app = builder.Build();

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=/api/Pharmacy}/{action=PharmacyPage}/{id?}"
//    //pattern:"api/Pharmacy/PharmacyPage",
//    //defaults: new { controller = "Pharmacy", action = "PharmacyPage" }
//    );
//app.MapControllerRoute(
//    name:"api",
//    pattern:"api/{controller}/{action}/{id?}",
//    defaults: "api/Pharmacy/PharmacyPage"
//    );
//app.UseMvc(route=> {
//    route.MapRoute(name: "default", template: "{controller=Pharmacy}/{action=PharmacyPage}/{id?}");
//});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "api",
        pattern: "api/{controller}/{action}/{id?}"
        );
    endpoints.MapControllerRoute(
        name: "view",
        pattern: "view/{controller}/{action}/{id?}",
        defaults: new { controller = "View/Pharmacy", action = "PharmacyPage" });
});
app.Run();
