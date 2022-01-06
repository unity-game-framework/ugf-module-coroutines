using UGF.Coroutines.Runtime;

namespace UGF.Module.Coroutines.Runtime
{
    public static class CoroutineModuleExtensions
    {
        public static CoroutineRunner CreateRunnerWithDefaultExecuter(this ICoroutineModule coroutineModule)
        {
            ICoroutineExecuter executer = coroutineModule.Executers.Get(coroutineModule.Description.DefaultExecuterId);

            return new CoroutineRunner(executer);
        }
    }
}
