// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Sddke.Shared.Application.Ports.System
{
    /// <summary>
    /// The system clock.
    /// </summary>
    public interface ISystemClock { DateTime GetCurrent(); }
}
