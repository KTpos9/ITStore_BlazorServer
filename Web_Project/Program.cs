using DataAccess;
using DataAccess.Data;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Web_Project.Authentication;
using Web_Project.Data;
using Web_Project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddTransient<SqlDataAccess>();
builder.Services.AddTransient<MemberData>();
builder.Services.AddTransient<ProductData>();
builder.Services.AddTransient<CartData>();
builder.Services.AddTransient<OrderData>();
builder.Services.AddMatBlazor();
builder.Services.AddMatToaster(config =>
{
    config.Position = MatToastPosition.TopCenter;
    config.PreventDuplicates = true;
    config.NewestOnTop = true;
    config.ShowCloseButton = true;
    config.MaximumOpacity = 95;
    config.VisibleStateDuration = 700;
});

var app = builder.Build();

// register syncfusion license
Bold.Licensing.BoldLicenseProvider.RegisterLicense("fpK4+uy+fl9xLzVuYDYDew9RExnvKpYLMMtYYvwLHU8=");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
