using System;
using System.Collections;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Coroutines.Runtime;
using UGF.Logs.Runtime;
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

            Log.Debug("Coroutine module initialize", new
            {
                defaultExecuter = Description.DefaultExecuterId,
                executers = Description.Executers.Count
            });

            foreach ((string key, ICoroutineExecuterBuilder value) in Description.Executers)
            {
                ICoroutineExecuter executer = value.Build();

                executer.Initialize();

                Executers.Add(key, executer);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Coroutine module uninitialize", new
            {
                executers = Executers.Entries.Count
            });

            foreach ((string _, ICoroutineExecuter value) in Executers.Entries)
            {
                value.Uninitialize();
            }

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
