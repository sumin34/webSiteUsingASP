using Microsoft.AspNetCore.Authentication.Cookies;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MySqlConnection>(
    option =>
new MySqlConnection(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
    {
        options.AccessDeniedPath = "/home/error";
        options.LoginPath = "/user/login";

    });


builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(1);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();//순서

app.UseAuthentication(); //지켜야


app.UseAuthorization();//합니다

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseSession(); //세션 사용하겠다는 문장 추가 run 이전에 적을것!

app.Run();
