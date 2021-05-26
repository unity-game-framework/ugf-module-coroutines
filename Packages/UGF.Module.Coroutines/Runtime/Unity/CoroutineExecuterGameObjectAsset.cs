using UGF.Coroutines.Runtime;
using UGF.Coroutines.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Coroutines/Coroutine Executer GameObject", order = 2000)]
    public class CoroutineExecuterGameObjectAsset : CoroutineExecuterAsset
    {
        [SerializeField] private string m_name = "CoroutineExecuterUnity";

        public string Name { get { return m_name; } set { m_name = value; } }

        protected override ICoroutineExecuter OnBuild()
        {
            return new CoroutineExecuterGameObject(m_name);
        }
    }
}
