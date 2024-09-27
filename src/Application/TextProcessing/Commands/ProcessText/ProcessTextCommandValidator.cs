using OneInc.Server.Application.TextProcessing.Commands.ProcessText;
using OneInc.Server.Domain.Constants;

namespace OneInc.Server.Application.TextProcessing.Commands.EncodeText;

public class ProcessTextCommandValidator : AbstractValidator<ProcessTextCommand>
{
    public ProcessTextCommandValidator()
    {
        RuleFor(x => x.Text)
            .Must(s => !string.IsNullOrWhiteSpace(s) )
            .WithMessage(ValidationErrorCode.NotNullOrEmpty);
    }
}
