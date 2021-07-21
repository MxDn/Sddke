namespace Sddke.Shared.Domain
{
    public static class Guard
    {
        public static TValue NotNull<TValue>(this TValue value)
        {
            if (value == null)
            {
                throw new DomainExecption(nameof(value));
            }

            return value;
        }

        public static string NotNullOrWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value) ? throw new DomainExecption(nameof(value)) : value;
    }
}
