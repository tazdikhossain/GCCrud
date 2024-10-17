using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class PersonalInfo
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string FullName { get; set; }

    [Required]
    public List<string> Email { get; set; } // Use string for a single email

    [Required]
    public List<string> Phone { get; set; }

    [StringLength(100, MinimumLength = 5)]
    public string Address { get; set; }

    [StringLength(200)]
    public string LinkedInUrl { get; set; }

    [StringLength(200)]
    public string GitHubUrl { get; set; }

    public virtual ICollection<Education> Educations { get; set; }
    public virtual ICollection<Experience> Experiences { get; set; }
    public virtual ICollection<Skills> Skills { get; set; }
    public virtual ICollection<Accomplishment> Accomplishments { get; set; }
}
