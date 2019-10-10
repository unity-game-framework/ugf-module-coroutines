using UGF.Description.Runtime;

namespace UGF.Module.Coroutines.Runtime
{
    public interface ICoroutineModuleDescription : IDescription
    {
        bool DontDestroyOnLoadExecuter { get; }
    }
}
