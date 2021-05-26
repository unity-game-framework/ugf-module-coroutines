using UGF.Coroutines.Runtime;
using UGF.Coroutines.Runtime.Unity;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime.Unity
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Coroutines/Coroutine Executer Unity", order = 2000)]
    public class CoroutineExecuterUnityAsset : CoroutineExecuterAsset
    {
        protected override ICoroutineExecuter OnBuild()
        {
            return new CoroutineExecuterUnity();
        }
    }
}
