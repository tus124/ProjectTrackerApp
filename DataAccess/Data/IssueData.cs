using DataAccessLayer.DbAccess;
using DataAccessLayer.Models;

namespace DataAccessLayer.Data;

public class IssueData : IIssueData
{
    public readonly ISqlDataAccess _db;

    public IssueData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<IssueModel>> GetIssuesByProjectId(int projectId) =>
        _db.LoadData<IssueModel, dynamic>("dbo.spIssue_GetAllByProjectId", new { projectId });

    public async Task<IssueModel?> GetIssue(int id)
    {
        var results = await _db.LoadData<IssueModel, dynamic>("dbo.spIssue_Get", new { id });
        return results.FirstOrDefault();
    }

    public Task InsertIssue(IssueModel model, string userName) =>
        _db.SaveData("dbo.spIssue_Insert", new
        {
            model.Title,
            model.Description,
            model.ProjectId,
            model.StatusId,
            model.AssignedToId,
            model.SprintId,
            model.SprintTypeId,
            model.CreatedBy
        });

    public Task UpdateIssue(IssueModel model, string userName) =>
        _db.SaveData("dbo.spIssue_Update", new
        {
            model.Id,
            model.Title,
            model.Description,
            model.ProjectId,
            model.StatusId,
            model.AssignedToId,
            model.SprintId,
            model.SprintTypeId,
            userName
        });

    public Task DeleteIssue(int id) =>
        _db.SaveData("dbo.spIssue_Delete", new { id });
}