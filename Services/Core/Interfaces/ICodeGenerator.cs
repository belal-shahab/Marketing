namespace marketing_api.Services.Core.Interfaces;

public interface ICodeRecipeGenerator
{
    string GenerateCode(int length);
}