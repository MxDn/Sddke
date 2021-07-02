// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Runtime.Serialization;

namespace Sddke.Shared.Application.Features.Command
{
    [Serializable]
    internal class ApplicationExecption : Exception
    {
        public ApplicationExecption()
        {
        }

        public ApplicationExecption(string message) : base(message)
        {
        }

        public ApplicationExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ApplicationExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
