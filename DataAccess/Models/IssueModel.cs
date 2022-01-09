namespace DataAccessLayer.Models;
public class IssueModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public int ProjectId { get; set; }

    public string Project { get; set; }

    public int StatusId { get; set; }

    public string Status { get; set; }

    public int AssignedToId { get; set; }

    public string AssignedTo { get; set; }

    public int SprintId { get; set; }

    public string Sprint { get; set; }

    public int SprintTypeId { get; set; }

    public string SprintType { get; set; }

    public string CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

 
    public DateTime? ModifiedDate { get; set; }
}