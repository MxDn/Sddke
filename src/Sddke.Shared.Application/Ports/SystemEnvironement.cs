namespace Sddke.Shared.Application.Ports
{
    /// <summary>
    /// The system environement.
    /// </summary>
    public interface SystemEnvironement
    {

        /// <summary>
        /// The get variable.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The result.</returns>
        TValue GetVariable<TValue>(string key);
    }
}
