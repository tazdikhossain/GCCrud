using FluentValidation;

public class EducationValidator : AbstractValidator<Education>
{
    public EducationValidator()
    {
        RuleFor(x => x.Institution).NotEmpty().Length(2, 100);
        RuleFor(x => x.Degree).NotEmpty().Length(2, 50);
        RuleFor(x => x.StartYear).InclusiveBetween(1900, 2100);
        RuleFor(x => x.EndYear).InclusiveBetween(1900, 2100).GreaterThan(x => x.StartYear);
    }
}
