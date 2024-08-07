﻿using DataAccessLayer.DbAccess;
using Microsoft.EntityFrameworkCore;
using ProjectTrackerDataAccess.Data;
using Microsoft.Extensions.DependencyInjection;
using ProjectTrackerUI.Data;
using ProjectTrackerDataAccess.LookupTables.Data;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<ProjectTrackerUIContext>(options =>

//    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjectTrackerUIContext")));

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();

//add lookup tables
builder.Services.AddSingleton<IPriorityData, PriorityData>();

//add primary tables
builder.Services.AddSingleton<IProjectData, ProjectData>();
builder.Services.AddSingleton<IFeatureData, FeatureData>();
builder.Services.AddSingleton<IIssueData, IssueData>();




//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    
    app.UseDeveloperExceptionPage();
    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapRazorPages();
app.Run();
