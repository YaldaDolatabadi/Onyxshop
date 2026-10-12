
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Onyxshop.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. در اینجا سرویس تعریف میشه بین این دو متغیر
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
#region context
builder.Services.AddDbContext<Onyxshop.Data.OnyxContext>
    (options => { options.UseSqlServer("Data Source =.;Initial Catalog=onyxshop;Integrated Security=true"); }); // نتونستم اینجا اس کیو ال تعریف کنم جاش چی کار کنم؟؟؟
//مشکل نوگت بود :))
#endregion

#region IOC
 builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
#endregion

#region authentication
//اضافه کردن سرویس احراز هویت از نوع کوکی و مشخص کردن اکشن های مربوط به لاگین و لاگ آوت
//باید در پایپلاین هم اضافه بشه
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
    option => {
        option.LoginPath = "/Account/login";
        option.LogoutPath = "/Account/logout";
        //انقضای کوکی و حذف توسط مرورگر (انتخاب من 20 روز بود)
        option.ExpireTimeSpan = TimeSpan.FromDays(20);
    }
    );
#endregion
var app = builder.Build();//اینجا نقطه فاصله بین سرویس و پایپلاینه

// Configure the HTTP request pipeline. پایپلاین اینجا
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages(); //اینم اضافه کردم که پوشه مربوط به ریزور پیج هامو بشناسه

app.Run();
