using Microsoft.IdentityModel.Tokens;

namespace GPUSpecServer.Helpers
{
    public static class ConvertHelper
    {
        public static int? SafeFloatToInt(float? value)
        {
            if (!value.HasValue)
            {
                return null;
            }
            return (int)value.Value;
        }

        public static string? SafeStringToNullableString(string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return value;
        }
    }
}
