//namespace ProjectTrackerAPI;

//public static class Api
//{
//    public static void ConfigureApi(this WebApplication app)
//    {
//        // All of the API endpoint mapping
//        app.MapGet("/Issues/{projectId}", GetIssues);
//        app.MapPost("/Issue", InsertIssue);
//        app.MapPut("/Issue", UpdateIssue);
//        app.MapDelete("/Issue", DeleteIssue);


        
//    }

//    private static async Task<IResult> GetIssues(int projectId, IIssueData data)
//    {
//        try
//        {
//            var results = await data.GetIssuesByProjectId(projectId);

//            if (results == null) return Results.NotFound();
            
//            return Results.Ok(results);

//        }
//        catch (Exception ex)
//        {
//            //Add Logging
//            return Results.Problem(ex.Message);
//        }
//    }

//    private static async Task<IResult> InsertIssue(IssueModel issue, string userName, IIssueData data)
//    {
//        try
//        {
//            await data.InsertIssue(issue, userName);

//            return Results.Ok();

//        }
//        catch (Exception ex)
//        {
//            //Add Logging
//            return Results.Problem(ex.Message);
//        }
//    }

//    private static async Task<IResult> UpdateIssue(IssueModel issue, string userName, IIssueData data)
//    {
//        try
//        {
//            await data.UpdateIssue(issue, userName);

//            return Results.Ok();

//        }
//        catch (Exception ex)
//        {
//            //Add Logging
//            return Results.Problem(ex.Message);
//        }
//    }

//    private static async Task<IResult> DeleteIssue(int id, IIssueData data)
//    {
//        try
//        {
//            await data.DeleteIssue(id);

//            return Results.Ok();

//        }
//        catch (Exception ex)
//        {
//            //Add Logging
//            return Results.Problem(ex.Message);
//        }
//    }
//}
