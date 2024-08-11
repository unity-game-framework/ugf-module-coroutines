using System.Collections;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Coroutines.Runtime
{
    public interface ICoroutineModule : IApplicationModule
    {
        ICoroutineModuleDescription Description { get; }
        IProvider<GlobalId, ICoroutineExecuter> Executers { get; }

        void Start(IEnumerator enumerator);
        void Stop(IEnumerator enumerator);
    }
}
