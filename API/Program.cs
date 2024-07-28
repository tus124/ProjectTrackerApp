using ProjectTrackerAPI;
using ProjectTrackerAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure services
builder.Services.AddSingleton<DAL>(new DAL("Server=(localdb)\\MSSQLLocalDB;Database=ProjectTracker;Integrated Security=true;"));


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();

// Call the extension method to map endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.MapProjectEndpoints();
});

app.Run();