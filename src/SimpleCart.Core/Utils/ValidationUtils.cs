namespace SimpleCart.Core.Utils;

public static class ValidationUtils
{
    public static bool IsValidReferenceId(string referenceId)
        => !string.IsNullOrEmpty(referenceId) && !string.IsNullOrWhiteSpace(referenceId) && referenceId.Length >= 16;

    public static bool IsValidQuantity(int x) => x >= 0;
    public static bool IsValidEntityId(int x) => x >= 0;
}