using System.ComponentModel.DataAnnotations;

public class Experience
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string CompanyName { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string JobTitle { get; set; }

    [Required]
    public int StartYear { get; set; }

    public int? EndYear { get; set; }

    public int PersonalInfoId { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
}
