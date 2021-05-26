using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Coroutines/Coroutine Module", order = 2000)]
    public class CoroutineModuleAsset : ApplicationModuleAsset<ICoroutineModule, CoroutineModuleDescription>
    {
        [AssetGuid(typeof(CoroutineExecuterAsset))]
        [SerializeField] private string m_defaultExecuter;
        [SerializeField] private List<AssetReference<CoroutineExecuterAsset>> m_executers = new List<AssetReference<CoroutineExecuterAsset>>();

        public string DefaultExecuter { get { return m_defaultExecuter; } set { m_defaultExecuter = value; } }
        public List<AssetReference<CoroutineExecuterAsset>> Executers { get { return m_executers; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new CoroutineModuleDescription
            {
                RegisterType = typeof(ICoroutineModule),
                DefaultExecuterId = m_defaultExecuter
            };

            for (int i = 0; i < m_executers.Count; i++)
            {
                AssetReference<CoroutineExecuterAsset> reference = m_executers[i];

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
