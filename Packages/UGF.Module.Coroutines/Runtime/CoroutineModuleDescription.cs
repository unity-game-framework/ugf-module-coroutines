using System;
using UnityEngine;

namespace UGF.Module.Coroutines.Runtime
{
    [Serializable]
    public class CoroutineModuleDescription : ICoroutineModuleDescription
    {
        [SerializeField] private bool m_dontDestroyOnLoadExecuter = true;

        public bool DontDestroyOnLoadExecuter { get { return m_dontDestroyOnLoadExecuter; } set { m_dontDestroyOnLoadExecuter = value; } }
    }
}
