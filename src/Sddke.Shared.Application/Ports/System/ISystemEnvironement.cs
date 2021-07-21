// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Sddke.Shared.Application.Ports.System
{
    /// <summary>
    /// The system environement.
    /// </summary>
    public interface ISystemEnvironement
    {
        /// <summary>
        /// The get variable.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>The result.</returns>
        TValue GetVariable<TValue>(string key);
    }
}
