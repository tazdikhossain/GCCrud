using System.ComponentModel.DataAnnotations;

public class Skills
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Language { get; set; }

    [Required]
    public string Reading { get; set; }

    [Required]
    public string Writing { get; set; }

    [Required]
    public string Speaking { get; set; }

    public int PersonalInfoId { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
}
