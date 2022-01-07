using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjectTrackerUI.Data;

var builder = WebApplication.CreateBuilder(args);
var identityDbConnectionString = builder.Configuration.GetConnectionString("IdentityDbConnection");
var logDbConnectionString = builder.Configuration.GetConnectionString("LogDbConnection");
var connectionString = builder.Configuration.GetConnectionString("ProjectTrackerConnection");

//Replace AddDbContext with AddDbContextPool because it enable DbContext pooling thus, it will not create a new instance every time but will check first if there are available instances in the pool and if there are, it will use one of those. 
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, builder =>

        builder.EnableRetryOnFailure(3, TimeSpan.FromSeconds(2), null)
    ));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
