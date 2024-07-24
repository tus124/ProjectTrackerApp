using ProjectTrackerApi;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddSingleton<DAL>(new DAL(""));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Define your API endpoints
app.MapPost("/execute/{procedureName}", async (HttpContext context, DAL dal) =>
{
    var procedureName = context.Request.RouteValues["procedureName"].ToString();
    var parameters = await context.Request.ReadFromJsonAsync<SqlParameter[]>();

    try
    {
        dal.ExecuteStoredProcedure(procedureName, parameters);
        await context.Response.WriteAsync("Stored procedure executed successfully.");
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsync($"Error executing stored procedure: {ex.Message}");
    }
});


app.Run();
