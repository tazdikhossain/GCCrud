using System.ComponentModel.DataAnnotations;

public class Accomplishment
{
    public int Id { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string Title { get; set; }

    [Url]
    public string Url { get; set; }

    public string Description { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Type { get; set; }

    public string IssuedOn { get; set; }

    public int PersonalInfoId { get; set; }
    public PersonalInfo PersonalInfo { get; set; }
}
