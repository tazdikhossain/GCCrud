using FluentValidation;

public class AccomplishmentValidator : AbstractValidator<Accomplishment>
{
    public AccomplishmentValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(2, 100);
        RuleFor(x => x.Url).NotEmpty().Must(BeAValidUrl).WithMessage("Invalid URL");
        RuleFor(x => x.Type).NotEmpty().Length(2, 50);
    }

    private bool BeAValidUrl(string url)
    {
        Uri uriResult;
        bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        return result;
    }
}
