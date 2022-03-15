using Blazored.LocalStorage;
using LaVillaHotelBookingSystem.Data;
using LaVillaHotelBookingSystem.Service;
using LaVillaHotelBookingSystem.Service.IService;
using LaVillaHotelBookingSystem.Services;
using LaVillaHotelBookingSystem.Services.IService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.IdentityModel.Logging;
using Models;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<WeatherForecastService>();
//builder.Services.AddScoped<CustomerBookingDetails>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IHotelRoomService, HotelRoomService>();
builder.Services.AddScoped<IHotelRoomTypeService, HotelRoomTypeService>();
builder.Services.AddScoped<IHotelAmenityService, HotelAmenityService>();
builder.Services.AddScoped<ICreatingBookingService, CreateBookingService>();

builder.Services.AddScoped<TokenProvider>();
builder.Services.AddHttpClient("HAIDP", client =>
{
    client.BaseAddress = new Uri("https://psl-app-vm3/HotelAdminAPI/");
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(options =>
{

    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme,
        options =>
        {
            options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
            options.Authority = "https://psl-app-vm3/HotelAdminIDP";
            options.ClientId = "La_Villa_Hotel";
            options.ClientSecret = "511536EF-F270-4058-81CB-1C89C192F622";

            // When set to code, the middleware will use PKCE protection
            options.ResponseType = "code";

            // The "openid" and "profile" scopes are added automatically,
            // so we don't need to add them for this test
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("HotelAdminAPI");

            // Save the tokens we receive from the IDP
            options.SaveTokens = true;

            // It's recommended to always get claims from the 
            // UserInfoEndpoint during the flow. 
            options.GetClaimsFromUserInfoEndpoint = true;
        });


var app = builder.Build();
//await builder.Build().RunAsync();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    
}
app.UseHsts();
IdentityModelEventSource.ShowPII = true;

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});
app.MapRazorPages();
app.UsePathBase("/LaVillaHotelBookingSystem");
//app.MapBlazorHub();
//app.MapFallbackToPage("/_Host");

app.Run();
