using DataBase.database;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//هذا السطر هو محرك الربط الفعلي في مشروعك؛ فهو يخبر نظام ASP.NET Core بكيفية إنشاء وإدارة جلسات التعامل مع قاعدة البيانات (Database Context).
builder.Services.AddDbContext<Connect>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("RentMasterConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
