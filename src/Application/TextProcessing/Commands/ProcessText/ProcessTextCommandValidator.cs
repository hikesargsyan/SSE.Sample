using App.Application.Common.Constants;

namespace App.Application.TextProcessing.Commands.ProcessText;

public class ProcessTextCommandValidator : AbstractValidator<ProcessTextCommand>
{

    public ProcessTextCommandValidator()
    {
        RuleFor(x => x.Text)
            .Must(s => !string.IsNullOrWhiteSpace(s))
            .WithMessage(ValidationErrorCode.NotNullOrEmpty)
            .MaximumLength(ValidationConstants.StringMaxLength)
            .WithMessage(ValidationErrorCode.MaxLength);
    }
}
