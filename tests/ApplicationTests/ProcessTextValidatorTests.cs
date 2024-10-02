using FluentValidation.TestHelper;
using OneInc.Server.Application.Common.Constants;
using OneInc.Server.Application.TextProcessing.Commands.ProcessText;

namespace ApplicationTests;

public class ProcessTextValidatorTests
{
    private readonly ProcessTextCommandValidator _validator;

    public ProcessTextValidatorTests()
    {
        _validator = new ProcessTextCommandValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Text_Is_Empty()
    {
        var command = new ProcessTextCommand("");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Text)
            .WithErrorMessage(ValidationErrorCode.NotNullOrEmpty);
    }

    [Fact]
    public void Should_Have_Error_When_Text_Is_Whitespace()
    {
        var command = new ProcessTextCommand("     ");
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Text)
            .WithErrorMessage(ValidationErrorCode.NotNullOrEmpty);
    }

    [Fact]
    public void Should_Have_Error_When_Text_Exceeds_Maximum_Length()
    {
        var command = new ProcessTextCommand(new string('a', 101));
        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Text)
            .WithErrorMessage(ValidationErrorCode.MaxLength);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Text_Is_Valid()
    {
        var command = new ProcessTextCommand("Text");
        var result = _validator.TestValidate(command);
        result.ShouldNotHaveValidationErrorFor(x => x.Text);
    }
}
