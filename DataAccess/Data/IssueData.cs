using DataAccessLayer.DbAccess;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public Task InsertIssue(IssueModel issue, string userName) =>
        _db.SaveData("dbo.spIssue_Insert", new
        {
            issue.Title,
            issue.Description,
            issue.ProjectId,
            issue.StatusId,
            issue.AssignedToId,
            issue.SprintId,
            issue.SprintTypeId,
            userName
        });

    public Task UpdateIssue(IssueModel issue, string userName) =>
        _db.SaveData("dbo.spIssue_Update", new
        {
            issue.Id,
            issue.Title,
            issue.Description,
            issue.ProjectId,
            issue.StatusId,
            issue.AssignedToId,
            issue.SprintId,
            issue.SprintTypeId,
            userName
        });

    public Task DeleteIssue(int id) =>
        _db.SaveData("dbo.spIssue_Delete", new { id });

}
