using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTrackerUI.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Project Name")]
        [Required]
        public string Name { get; set; } = "default name";

        [Display(Name = "Description")]
        public string Description { get; set; } = "default description";

        [Display(Name = "Active")]
        public bool Active { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; } = "default created by";

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Modified By")]
        public string? ModifiedBy { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime ModifiedDate { get; set; }

    }
}
