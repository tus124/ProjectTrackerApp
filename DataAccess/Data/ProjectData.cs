using DataAccessLayer.DbAccess;
using DataAccessLayer.Models;

namespace ProjectTrackerDataAccess.Data;

public class ProjectData : IProjectData
{
    public readonly ISqlDataAccess _db;

    public ProjectData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<ProjectModel>> GetProjects() =>
     _db.LoadData<ProjectModel, dynamic>("dbo.spProject_GetAll", new { });

    public async Task<ProjectModel?> GetProject(int id)
    {
        var results = await _db.LoadData<ProjectModel, dynamic>("dbo.spProject_Get", new { id });
        return results.FirstOrDefault();
    }

    public Task InsertProject(ProjectModel model, string userName)
    {
        model.CreatedBy = userName;
        return _db.SaveData("dbo.spProject_Insert", new
        {
            model.Name,
            model.Description,
            model.Active,
            model.CreatedBy
        });
    }
       

    public Task UpdateProject(ProjectModel model, string userName)
    {
        model.ModifiedBy = userName;

        return _db.SaveData("dbo.spProject_Update", new
        {
            model.Id,
            model.Name,
            model.Description,
            model.Active,
            model.ModifiedBy
        });
    }
      

public Task DeleteProject(int id) =>
        _db.SaveData("dbo.spProject_Delete", new { id });
}