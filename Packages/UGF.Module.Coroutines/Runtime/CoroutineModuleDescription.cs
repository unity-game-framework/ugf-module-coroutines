using System;
using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Coroutines.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Coroutines.Runtime
{
    public class CoroutineModuleDescription : ApplicationModuleDescription, ICoroutineModuleDescription
    {
        public GlobalId DefaultExecuterId { get; }
        public IReadOnlyDictionary<GlobalId, IBuilder<ICoroutineExecuter>> Executers { get; }

        public CoroutineModuleDescription(GlobalId defaultExecuterId, IReadOnlyDictionary<GlobalId, IBuilder<ICoroutineExecuter>> executers)
        {
            if (!defaultExecuterId.IsValid()) throw new ArgumentException("Value should be valid.", nameof(defaultExecuterId));

            DefaultExecuterId = defaultExecuterId;
            Executers = executers ?? throw new ArgumentNullException(nameof(executers));
        }
    }
}
