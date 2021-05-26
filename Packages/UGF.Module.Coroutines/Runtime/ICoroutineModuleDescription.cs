using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Coroutines.Runtime
{
    public interface ICoroutineModuleDescription : IApplicationModuleDescription
    {
        string DefaultExecuterId { get; }
        IReadOnlyDictionary<string, ICoroutineExecuterBuilder> Executers { get; }
    }
}
