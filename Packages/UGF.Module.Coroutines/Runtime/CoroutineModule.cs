using System;
using System.Collections;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime.Unity;

namespace UGF.Module.Coroutines.Runtime
{
    public class CoroutineModule : ApplicationModuleBase, ICoroutineModule
    {
        public ICoroutineModuleDescription Description { get; }

        private CoroutineExecuterUnity m_executer;

        public CoroutineModule(ICoroutineModuleDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            m_executer = new CoroutineExecuterUnity("CoroutineModuleExecuter", Description.DontDestroyOnLoadExecuter);
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_executer.Dispose();
            m_executer = null;
        }

        public void Start(IEnumerator routine)
        {
            if (routine == null) throw new ArgumentNullException(nameof(routine));
            if (m_executer == null) throw new InvalidOperationException("Executer not created.");

            m_executer.Start(routine);
        }

        public void Stop(IEnumerator routine)
        {
            if (routine == null) throw new ArgumentNullException(nameof(routine));
            if (m_executer == null) throw new InvalidOperationException("Executer not created.");

            m_executer.Stop(routine);
        }
    }
}
