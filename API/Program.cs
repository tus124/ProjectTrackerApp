using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProjectTrackerAPI;
using ProjectTrackerAPI.Models;
using System.Data.SqlClient;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddSingleton<DAL>(new DAL("Server=(localdb)\\MSSQLLocalDB;Database=ProjectTracker;Integrated Security=true;"));   //InitialCatalog=ProjectTracker;

var app = builder.Build();





// Define your API endpoints

app.MapGet("/execute-project-{procedureName}", async (HttpContext context, DAL dal) =>
{
    var procedureName = context.Request.RouteValues["procedureName"].ToString();

    try
    {
        var results = dal.ExecuteStoredProcedureForProject(procedureName, null);

        var output = JsonConvert.SerializeObject(results);

        await context.Response.WriteAsync("Project Stored procedure executed successfully. Records count: " + results.Count + "\n");
        await context.Response.WriteAsync(output);
    }
    catch (Exception ex)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsync($"Error executing project stored procedure: {ex.Message}");
    }
});


app.MapPost("/execute-{procedureName}", async (HttpContext context, DAL dal) =>
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