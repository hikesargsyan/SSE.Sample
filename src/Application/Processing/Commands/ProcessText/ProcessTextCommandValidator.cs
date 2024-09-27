using OneInc.Server.Application.Processing.Commands.ProcessText;
using OneInc.Server.Domain.Constants;

namespace OneInc.Server.Application.Processing.Commands.EncodeText;

public class ProcessTextCommandValidator : AbstractValidator<ProcessTextCommand>
{
    public ProcessTextCommandValidator()
    {
        RuleFor(x => x.Text)
            .Must(s => !string.IsNullOrWhiteSpace(s) )
            .WithMessage(ValidationErrorCode.NotNullOrEmpty);
    }
}
