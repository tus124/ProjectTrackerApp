namespace ProjectTrackerAPI.Endpoints;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Text.Json;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

public static class EndpointExtensions
{
    public static void MapProjectEndpoints(this IEndpointRouteBuilder endpoints)
    {
        //endpoints.MapGet("/execute-project-{procedureName}", async (HttpContext context, DAL dal) =>
        //{
        //    var procedureName = context.Request.RouteValues["procedureName"]?.ToString();

        //    if (string.IsNullOrEmpty(procedureName))
        //    {
        //        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        //        await context.Response.WriteAsync("Procedure name is required.");
        //        return;
        //    }

        //    try
        //    {
        //        var results = dal.ExecuteStoredProcedureForProject(procedureName, null);

        //        context.Response.ContentType = "application/json";

        //        // Serialize the object to a JSON string
        //        var json = JsonSerializer.Serialize(results);

        //        // Write the JSON string to the response body
        //        await context.Response.WriteAsync(json);
        //    }
        //    catch (Exception ex)
        //    {
        //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        //        await context.Response.WriteAsync($"Error executing {procedureName} : {ex.Message}");
        //    }
        //}).WithName("GetAllProjects");


        endpoints.MapGet("/execute-project-{procedureName}", async (HttpContext context, DAL dal) =>
        {
            var procedureName = context.Request.RouteValues["procedureName"]?.ToString();
            var query = context.Request.Query;


            if (string.IsNullOrEmpty(procedureName))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Procedure name is required.");
                return;
            }

            // Convert query string to SqlParameter[]
            var parameters = new List<SqlParameter>();
            foreach (var key in query.Keys)
            {
                parameters.Add(new SqlParameter(key, query[key].ToString()));
            }

            try
            {
                var results = dal.ExecuteStoredProcedureForProject(procedureName, parameters.ToArray());

                context.Response.ContentType = "application/json";

                // Serialize the object to a JSON string
                var json = JsonSerializer.Serialize(results);

                // Write the JSON string to the response body
                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Error executing {procedureName} : {ex.Message}");
            }
        });



        endpoints.MapPost("/execute-{procedureName}", async (HttpContext context, DAL dal) =>
        {
            var procedureName = context.Request.RouteValues["procedureName"].ToString();
            var parameters = await context.Request.ReadFromJsonAsync<SqlParameter[]>();

            try
            {
                dal.ExecuteStoredProcedureForProject(procedureName, parameters);
                await context.Response.WriteAsync(procedureName + " executed successfully.");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Error executing stored procedure: {ex.Message}");
            }
        });
    }
}
