using System;
using System.Collections;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Coroutines.Runtime
{
    public class CoroutineModule : ApplicationModule<CoroutineModuleDescription>, ICoroutineModule
    {
        public IProvider<string, ICoroutineExecuter> Executers { get; }

        ICoroutineModuleDescription ICoroutineModule.Description { get { return Description; } }

        public CoroutineModule(CoroutineModuleDescription description, IApplication application) : this(description, application, new Provider<string, ICoroutineExecuter>())
        {
        }

        public CoroutineModule(CoroutineModuleDescription description, IApplication application, IProvider<string, ICoroutineExecuter> executers) : base(description, application)
        {
            Executers = executers ?? throw new ArgumentNullException(nameof(executers));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (KeyValuePair<string, ICoroutineExecuterBuilder> pair in Description.Executers)
            {
                ICoroutineExecuter executer = pair.Value.Build();

                Executers.Add(pair.Key, executer);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Executers.Clear();
        }

        public void Start(IEnumerator enumerator)
        {
            ICoroutineExecuter executer = Executers.Get(Description.DefaultExecuterId);

            executer.Start(enumerator);
        }

        public void Stop(IEnumerator enumerator)
        {
            ICoroutineExecuter executer = Executers.Get(Description.DefaultExecuterId);

            executer.Stop(enumerator);
        }
    }
}
