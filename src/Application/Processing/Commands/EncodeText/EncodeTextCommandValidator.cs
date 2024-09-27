using OneInc.Server.Domain.Constants;

namespace OneInc.Server.Application.Processing.Commands.EncodeText;

public class EncodeTextCommandValidator : AbstractValidator<EncodeTextCommand>
{
    public EncodeTextCommandValidator()
    {
        RuleFor(x => x.Text)
            .Must(s => !string.IsNullOrWhiteSpace(s) )
            .WithMessage(ValidationErrorCode.NotNullOrEmpty);
    }
}
