using DataAccessLayer.DbAccess;
using ProjectTrackerDataAccess.LookupTables.Models;

namespace ProjectTrackerDataAccess.LookupTables.Data;

public class PriorityData : IPriorityData
{
    public readonly ISqlDataAccess _db;
    public PriorityData(ISqlDataAccess db)
    {
        _db = db;
    }


    public Task<IEnumerable<PriorityModel>> GetAll() =>
        _db.LoadData<PriorityModel, dynamic>("dbo.spPriority_GetAll", new { });

    public async Task<PriorityModel?> Get(int id)
    {
        var results = await _db.LoadData<PriorityModel, dynamic>("dbo.spPriority_Get", new { id });

        return results.FirstOrDefault();
    }


}
