namespace ProjectTrackerDataAccess.Models;

public class FeatureModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int PriorityId { get; set; }
    public int RiskId { get; set; }
    public int ClassificationId { get; set; }
    public bool Active { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
