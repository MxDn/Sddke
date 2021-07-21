using System;

using Sddke.Shared.Application.Ports.System;

namespace Sddke.Shared.Infrastructure.Adapters
{
    public class SystemClock : ISystemClock
    {
        public DateTime GetCurrent() => DateTime.Now;
    }
}
