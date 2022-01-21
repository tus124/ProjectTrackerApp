using ProjectTrackerDataAccess.LookupTables.Models;

namespace ProjectTrackerDataAccess.LookupTables.Data;

public interface IPriorityData
{
    Task<PriorityModel?> Get(int id);
    Task<IEnumerable<PriorityModel>> GetAll();
}