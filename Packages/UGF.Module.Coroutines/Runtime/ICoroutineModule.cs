using System.Collections;
using UGF.Application.Runtime;

namespace UGF.Module.Coroutines.Runtime
{
    public interface ICoroutineModule : IApplicationModule
    {
        ICoroutineModuleDescription Description { get; }

        void Start(IEnumerator routine);
        void Stop(IEnumerator routine);
    }
}
