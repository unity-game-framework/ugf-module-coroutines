using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Coroutines.Runtime
{
    public class CoroutineModuleDescription : ApplicationModuleDescription, ICoroutineModuleDescription
    {
        public string DefaultExecuterId { get; set; }
        public Dictionary<string, ICoroutineExecuterBuilder> Executers { get; } = new Dictionary<string, ICoroutineExecuterBuilder>();

        IReadOnlyDictionary<string, ICoroutineExecuterBuilder> ICoroutineModuleDescription.Executers { get { return Executers; } }
    }
}
