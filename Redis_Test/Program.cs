using Microsoft.EntityFrameworkCore;
using Redis_Test.Models;
using Redis_Test.Models.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



#region Redis init
var redis=new MyRedis();
redis.SetString("InitMsg", $"Hi Redis  init  time  is  {DateTime.Now}");

builder.Services.AddSingleton(redis);
#endregion
//builder.Services.AddScoped<MyRedis>();
builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
}, ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

#region Init DB

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TestDbContext>();
    // 檢查資料庫是否已建立
    context.Database.EnsureCreated();

    if (context.Game11s.Any())
    {
        
    }
}

#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
