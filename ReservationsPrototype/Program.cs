using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationsPrototype.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions =>
{
    cookieOptions.LoginPath = "/";
});
IMvcBuilder mvcBuilder = builder.Services.AddMvc()
    .AddRazorPagesOptions(options => _ = options.Conventions.AuthorizeFolder("/Reservations"));//.SetCompatibilityVersion(version: CompatibilityVersion.Version_3_0);

builder.Services.AddDbContext<ProvidersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProvidersContext") ?? throw new InvalidOperationException("Connection string 'ProvidersContext' not found.")));
builder.Services.AddDbContext<HotelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext") ?? throw new InvalidOperationException("Connection string 'HotelContext' not found.")));
builder.Services.AddDbContext<ReservationsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerContext") ?? throw new InvalidOperationException("Connection string 'CostumerContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
