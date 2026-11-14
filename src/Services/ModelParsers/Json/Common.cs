using System.Text.Json;

namespace Services.ModelParsers.Json;

internal static class Common
{
    internal static JsonSerializerOptions JsonSerializerOptions { get; } =
        new() { PropertyNameCaseInsensitive = true, AllowTrailingCommas = true };
}
