using System;
using System.Collections;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Coroutines.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Coroutines.Runtime
{
    public class CoroutineModule : ApplicationModule<CoroutineModuleDescription>, ICoroutineModule
    {
        public IProvider<GlobalId, ICoroutineExecuter> Executers { get; }

        ICoroutineModuleDescription ICoroutineModule.Description { get { return Description; } }

        private readonly ILog m_logger;

        public CoroutineModule(CoroutineModuleDescription description, IApplication application) : this(description, application, new Provider<GlobalId, ICoroutineExecuter>())
        {
        }

        public CoroutineModule(CoroutineModuleDescription description, IApplication application, IProvider<GlobalId, ICoroutineExecuter> executers) : base(description, application)
        {
            Executers = executers ?? throw new ArgumentNullException(nameof(executers));

            m_logger = Log.CreateWithLabel<CoroutineModule>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            m_logger.Debug("Initialize", new
            {
                defaultExecuter = Description.DefaultExecuterId,
                executers = Description.Executers.Count
            });

            foreach ((GlobalId id, IBuilder<ICoroutineExecuter> value) in Description.Executers)
            {
                ICoroutineExecuter executer = value.Build();

                executer.Initialize();

                Executers.Add(id, executer);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_logger.Debug("Uninitialize", new
            {
                executers = Executers.Entries.Count
            });

            foreach ((_, ICoroutineExecuter value) in Executers.Entries)
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
