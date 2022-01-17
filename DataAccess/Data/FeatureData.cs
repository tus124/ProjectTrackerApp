using DataAccessLayer.DbAccess;
using DataAccessLayer.Models;
using ProjectTrackerDataAccess.Models;

namespace DataAccessLayer.Data;

public class FeatureData : IFeatureData
{
    public readonly ISqlDataAccess _db;

    public FeatureData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<FeatureModel>> GetFeaturesByProjectId(int projectId) =>
        _db.LoadData<FeatureModel, dynamic>("dbo.spFeature_GetAllByProjectId", new { projectId });

    public async Task<FeatureModel?> GetFeature(int id)
    {
        var results = await _db.LoadData<FeatureModel, dynamic>("dbo.spFeature_Get", new { id });
        return results.FirstOrDefault();
    }

    public Task InsertFeature(FeatureModel model, string userName)
    {
        model.CreatedBy = userName;

        return _db.SaveData("dbo.spFeature_Insert", new
        {
            model.Title,
            model.Description,
            model.ProjectId,
            model.PriorityId,
            model.RiskId,
            model.ClassificationId,
            model.Active,
            model.CreatedBy
        });
    }


    public Task UpdateFeature(FeatureModel model, string userName)
    {
        model.CreatedBy = userName;

        return _db.SaveData("dbo.spFeature_Update", new
        {
            model.Id,
            model.Title,
            model.Description,
            model.ProjectId,
            model.PriorityId,
            model.RiskId,
            model.ClassificationId,
            model.Active,
            model.ModifiedBy
        });
    }
       

    public Task DeleteFeature(int id) =>
        _db.SaveData("dbo.spFeature_Delete", new { id });
}