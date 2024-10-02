using OneInc.Server.Application.Common.Constants;

namespace OneInc.Server.Application.TextProcessing.Commands.ProcessText;

public class ProcessTextCommandValidator : AbstractValidator<ProcessTextCommand>
{
    public ProcessTextCommandValidator()
    {
        RuleFor(x => x.Text)
            .Must(s => !string.IsNullOrWhiteSpace(s) )
            .WithMessage(ValidationErrorCode.NotNullOrEmpty)
            .MaximumLength(100)
            .WithMessage(ValidationErrorCode.MaxLength);;
    }
}
