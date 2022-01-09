using DataAccessLayer.Models;

namespace DataAccessLayer.Data;

public interface IIssueData
{
    Task DeleteIssue(int id);
    Task<IssueModel?> GetIssue(int id);
    Task<IEnumerable<IssueModel>> GetIssuesByProjectId(int projectId);
    Task InsertIssue(IssueModel issue, string userName);
    Task UpdateIssue(IssueModel issue, string userName);
}