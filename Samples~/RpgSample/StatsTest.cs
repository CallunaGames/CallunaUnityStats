using Calluna.DI;
using UnityEngine;

namespace Calluna.Stats.Samples.Rpg
{
    public class StatsTest : MonoBehaviour, Injectable
    {
        private StatsCollection _statsCollection;
        
        public void Inject(Resolver resolver)
        {
            _statsCollection = resolver.Resolve<StatsCollection>();
        }
    }
}
