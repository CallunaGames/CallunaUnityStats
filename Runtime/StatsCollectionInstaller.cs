using System.Collections.Generic;
using Calluna.DI;
using UnityEngine;

namespace Calluna.Stats
{
    public class StatsCollectionInstaller : MonoInstaller
    {
        [SerializeField] private List<StatValueDefinition> _stats = new List<StatValueDefinition>();
        
        public override void InstallBindings(Binder binder)
        {
            binder.BindToSelf<StatsCollection>().FromMethod(CreateCollection).AsSingle();
        }

        private StatsCollection CreateCollection()
        {
            return StatsCollection.Create(_stats);
        }
    }
}