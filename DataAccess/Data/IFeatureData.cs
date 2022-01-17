using ProjectTrackerDataAccess.Models;

namespace DataAccessLayer.Data;

public interface IFeatureData
{
    Task DeleteFeature(int id);
    Task<FeatureModel?> GetFeature(int id);
    Task<IEnumerable<FeatureModel>> GetFeaturesByProjectId(int projectId);
    Task InsertFeature(FeatureModel issue, string userName);
    Task UpdateFeature(FeatureModel issue, string userName);
}