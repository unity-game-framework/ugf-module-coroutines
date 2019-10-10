using UGF.Application.Runtime;
using UGF.Module.Runtime;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Coroutines/CoroutineModuleBuilder", order = 2000)]
    public class CoroutineModuleBuilderAsset : ModuleBuilderAsset<ICoroutineModule, CoroutineModuleDescription>
    {
        protected override IApplicationModule OnBuild(IApplication application, CoroutineModuleDescription description)
        {
            return new CoroutineModule(description);
        }
    }
}
