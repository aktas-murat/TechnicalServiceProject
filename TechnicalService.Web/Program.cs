using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TechnicalService.Data.Data;
using TechnicalService.Core.Identity;
using TechnicalService.Core.Services.Email;
using System.Reflection;
using TechnicalService.Business.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);
var con1 = builder.Configuration.GetConnectionString("con1");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(con1));
builder.Services.AddSession();
builder.Services.AddTransient<IEmailService, SmtpEmailService>();
builder.Services.AddAutoMapper(options =>
{
    options.AddProfile<MapperProfile>();
});
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.AllowedForNewUsers = false;

    // User settings.
    options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
