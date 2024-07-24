namespace ProjectTrackerAPI;

using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly DAL _dal;

    public ApiController(DAL dal)
    {
        _dal = dal;
    }

    [HttpPost("{procedureName}")]
    public IActionResult ExecuteStoredProcedure(string procedureName, [FromBody] SqlParameter[] parameters)
    {
        try
        {
            _dal.ExecuteStoredProcedure(procedureName, parameters);
            return Ok("Stored procedure executed successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error executing stored procedure: {ex.Message}");
        }
    }
}