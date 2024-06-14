using marketing_api.Services.Core.Interfaces;

namespace marketing_api.Services.Core;

public class CodeRecipeGenerator : ICodeRecipeGenerator
{
    const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private readonly Random _random = new();

    public string GenerateCode(int length)
    {
        return new string(Enumerable.Repeat(Chars, length).Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}