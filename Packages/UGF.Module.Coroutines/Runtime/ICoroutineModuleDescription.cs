using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Coroutines.Runtime
{
    public interface ICoroutineModuleDescription : IApplicationModuleDescription
    {
        GlobalId DefaultExecuterId { get; }
        IReadOnlyDictionary<GlobalId, ICoroutineExecuterBuilder> Executers { get; }
    }
}
