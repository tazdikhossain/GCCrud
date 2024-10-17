using System.ComponentModel.DataAnnotations;

public class Education
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Institution { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Degree { get; set; }

    [Required]
    public int StartYear { get; set; }

    [Required]
    public int EndYear { get; set; }

    public string Result { get; set; }
    public string Duration { get; set; }
    public string Achievement { get; set; }

    public int PersonalInfoId { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
}
