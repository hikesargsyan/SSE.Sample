using System.Text.RegularExpressions;

namespace App.Api.Common;

public partial class KebabCaseTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        var stringValue = value?.ToString();
        
        if (string.IsNullOrWhiteSpace(stringValue))
        {
            return null;
        }

        return EnglishLettersRegex()
            .Replace(stringValue, "$1-$2")
            .ToLower();
    }


    [GeneratedRegex("([a-z])([A-Z])")]
    private static partial Regex EnglishLettersRegex();
}
