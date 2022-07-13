using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Coroutines/Coroutine Module", order = 2000)]
    public class CoroutineModuleAsset : ApplicationModuleAsset<ICoroutineModule, CoroutineModuleDescription>
    {
        [AssetId(typeof(CoroutineExecuterAsset))]
        [SerializeField] private GlobalId m_defaultExecuter;
        [SerializeField] private List<AssetIdReference<CoroutineExecuterAsset>> m_executers = new List<AssetIdReference<CoroutineExecuterAsset>>();

        public GlobalId DefaultExecuter { get { return m_defaultExecuter; } set { m_defaultExecuter = value; } }
        public List<AssetIdReference<CoroutineExecuterAsset>> Executers { get { return m_executers; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new CoroutineModuleDescription
            {
                RegisterType = typeof(ICoroutineModule),
                DefaultExecuterId = m_defaultExecuter
            };

            for (int i = 0; i < m_executers.Count; i++)
            {
                AssetIdReference<CoroutineExecuterAsset> reference = m_executers[i];

                description.Executers.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override ICoroutineModule OnBuild(CoroutineModuleDescription description, IApplication application)
        {
            return new CoroutineModule(description, application);
        }
    }
}
