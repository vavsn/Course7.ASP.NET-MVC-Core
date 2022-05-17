using CoureProject.Domain;
using CoureProject.Interfaces;
using CoureProject.WebAPI.Clients;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddControllersWithViews();

services.AddHttpClient("WeathersWebAPI", client => client.BaseAddress = new(builder.Configuration["WebAPI"]))
    .AddTypedClient<IRepositoryAsync<Consolidated_Weather>, WeatherClient>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
