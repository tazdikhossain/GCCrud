using FluentValidation;

public class ExperienceValidator : AbstractValidator<Experience>
{
    public ExperienceValidator()
    {
        RuleFor(x => x.CompanyName).NotEmpty().Length(2, 100);
        RuleFor(x => x.JobTitle).NotEmpty().Length(2, 100);
        RuleFor(x => x.StartYear).InclusiveBetween(1900, 2100);
        RuleFor(x => x.EndYear).InclusiveBetween(1900, 2100).GreaterThanOrEqualTo(x => x.StartYear).When(x => x.EndYear != null);
    }
}
