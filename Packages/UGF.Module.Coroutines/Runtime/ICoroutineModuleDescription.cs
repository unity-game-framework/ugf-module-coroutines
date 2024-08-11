using System.Collections.Generic;
using UGF.Builder.Runtime;
using UGF.Coroutines.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Coroutines.Runtime
{
    public interface ICoroutineModuleDescription : IDescription
    {
        GlobalId DefaultExecuterId { get; }
        IReadOnlyDictionary<GlobalId, IBuilder<ICoroutineExecuter>> Executers { get; }
    }
}
