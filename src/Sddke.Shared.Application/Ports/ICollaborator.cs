// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Sddke.Shared.Application.Ports
{
    /// <summary>
    /// The i collaborator.
    /// </summary>
    public interface ICollaborator
    {
        void BeforeHandle(object input);
        void AfterHandle(object outpu);
    }
}
