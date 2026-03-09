using System.Collections.Generic;
using Calluna.DI;
using UnityEngine;

namespace Calluna.Stats.Samples.Rpg
{
    public class StatsDisplay : MonoBehaviour, Injectable, Initializable
    {
        [SerializeField] private RectTransform _hook;
        [SerializeField] private StatsDisplayEntry _entryPrefab;
        private StatsCollection _statsCollection;
        private PrefabFactory _prefabFactory;
        private List<StatsDisplayEntry> _entries = new List<StatsDisplayEntry>();
        
        public void Inject(Resolver resolver)
        {
            _statsCollection = resolver.Resolve<StatsCollection>();
            _prefabFactory = resolver.Resolve<PrefabFactory>();
        }

        public void Initialize()
        {
            foreach (Stat stat in _statsCollection.Stats)
            {
                StatsDisplayEntry entry = _prefabFactory.Create(_entryPrefab, stat);
                entry.transform.SetParent(_hook);
                _entries.Add(entry);
            }
        }
    }
}
