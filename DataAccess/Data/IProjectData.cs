using DataAccessLayer.Models;

namespace ProjectTrackerDataAccess.Data;

public interface IProjectData
{
    Task DeleteProject(int id);
    Task<ProjectModel?> GetProject(int id);
    Task<IEnumerable<ProjectModel>> GetProjects();
    Task InsertProject(ProjectModel model, string userName);
    Task UpdateProject(ProjectModel model, string userName);
}