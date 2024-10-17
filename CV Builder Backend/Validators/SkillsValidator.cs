using FluentValidation;

public class SkillsValidator : AbstractValidator<Skills>
{
    public SkillsValidator()
    {
        RuleFor(x => x.Language).NotEmpty().Length(2, 50);
        RuleFor(x => x.Reading).NotEmpty().Length(2, 50);
        RuleFor(x => x.Writing).NotEmpty().Length(2, 50);
        RuleFor(x => x.Speaking).NotEmpty().Length(2, 50);
    }
}
