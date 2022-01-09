using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerUI.Models;

[Table("Issue")]
public class Issue
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Title")]
    [Required]
    public string Title { get; set; }

    [Display(Name = "Description")]
    public string Description { get; set; }

    [Display(Name = "ProjectId")]
    public int ProjectId { get; set; }

    [Display(Name = "StatusId")]
    public int StatusId { get; set; }

    [Display(Name = "AssignedToId")]
    public int AssignedToId { get; set; }

    [Display(Name = "SprintId")]
    public int SprintId { get; set; }

    [Display(Name = "SprintTypeId")]
    public int SprintTypeId { get; set; }


    [Display(Name = "Created By")]
    public string CreatedBy { get; set; }

    [Display(Name = "Created Date")]
    public DateTime CreatedDate { get; set; }

    [Display(Name = "Modified By")]
    public string? ModifiedBy { get; set; }

    [Display(Name = "Modified Date")]
    public DateTime? ModifiedDate { get; set; }
}
