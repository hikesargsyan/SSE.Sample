using App.Application.Common.Constants;

namespace App.Application.TextProcessing.Commands.EncodeText;

public class EncodeTextCommandValidator : AbstractValidator<EncodeTextCommand>
{
    public EncodeTextCommandValidator()
    {
        RuleFor(x => x.Text)
            .Must(s => !string.IsNullOrWhiteSpace(s) )
            .WithMessage(ValidationErrorCode.NotNullOrEmpty)
            .MaximumLength(100)
            .WithMessage(ValidationErrorCode.MaxLength);
    }
}
