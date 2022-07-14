using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Coroutines.Runtime
{
    public class CoroutineModuleDescription : ApplicationModuleDescription, ICoroutineModuleDescription
    {
        public GlobalId DefaultExecuterId { get; set; }
        public Dictionary<GlobalId, ICoroutineExecuterBuilder> Executers { get; } = new Dictionary<GlobalId, ICoroutineExecuterBuilder>();

        IReadOnlyDictionary<GlobalId, ICoroutineExecuterBuilder> ICoroutineModuleDescription.Executers { get { return Executers; } }
    }
}
