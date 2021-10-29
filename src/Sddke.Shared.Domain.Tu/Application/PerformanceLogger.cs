using System;
using Sddke.Shared.Application.Ports;
using Xunit.Abstractions;

namespace Sddke.Shared.Tu.Application
{
    public class TestPerformanceLogger : ICollaborator
        {
            private ITestOutputHelper output;

        public TestPerformanceLogger()
        {
        }

        public TestPerformanceLogger(ITestOutputHelper output)
            {
                this.output = output;
            }

            internal void Log(object command)
            {
                this.output.WriteLine($"{DateTime.Now.ToLongTimeString()}-{DateTime.Now.Millisecond}-{command.ToString()}"); 
            }
        }
}
