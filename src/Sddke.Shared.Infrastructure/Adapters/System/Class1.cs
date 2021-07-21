using System.Collections.Generic;

using Sddke.Shared.Application.Ports.System;

namespace Sddke.Shared.Infrastructure.Adapters.System
{
    public class InMemoryDictionaryBasedSystemEnvironement : ISystemEnvironement
    {
        private readonly IDictionary<string, object> variables = new Dictionary<string, object>();

        public InMemoryDictionaryBasedSystemEnvironement(IDictionary<string, object> variables) => this.variables = variables;

        public TValue GetVariable<TValue>(string key) => variables.ContainsKey(key) ? (TValue)variables[key] : throw new InfrastructureExecption(nameof(key));
    }
}
