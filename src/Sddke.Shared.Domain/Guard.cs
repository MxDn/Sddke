 

namespace Sddke.Shared.Domain
{
    /// <summary>
    /// The guard.
    /// </summary>
    public static class Guard
    {
        /// <summary>
        /// The not null.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        public static TValue NotNull<TValue>(this TValue value)
        {
            if (value == null) throw new DomainExecption(nameof(value));
            return value;
        }

        /// <summary>
        /// The not null or white space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        public static string NotNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? throw new DomainExecption(nameof(value)) : value;
        }
    }
}
