using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Module.Coroutines/CoroutineModuleInfo", order = 2000)]
    public class CoroutineModuleInfoAsset : ApplicationModuleInfoAsset<ICoroutineModule>
    {
        [SerializeField] private bool m_dontDestroyOnLoadExecuter = true;

        public bool DontDestroyOnLoadExecuter { get { return m_dontDestroyOnLoadExecuter; } set { m_dontDestroyOnLoadExecuter = value; } }

        public ICoroutineModuleDescription GetDescription()
        {
            return new CoroutineModuleDescription
            {
                DontDestroyOnLoadExecuter = m_dontDestroyOnLoadExecuter
            };
        }

        protected override IApplicationModule OnBuild(IApplication application)
        {
            ICoroutineModuleDescription description = GetDescription();

            return new CoroutineModule(description);
        }
    }
}
