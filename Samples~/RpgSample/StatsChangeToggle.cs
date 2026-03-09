using Calluna.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Calluna.Stats.Samples.Rpg
{
    public class StatsChangeToggle : MonoBehaviour, Injectable, Initializable, Cleanable
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private string _name;
        [SerializeField] private StatChangesDefinition _changes;

        private StatsCollection _statsCollection;
        private NamedModifierSource _source;

        public void Inject(Resolver resolver)
        {
            _statsCollection = resolver.Resolve<StatsCollection>();
            _source = new NamedModifierSource(GetInstanceID().ToString(), _name);
        }

        public void Initialize()
        {
            OnChanged(_toggle.isOn);
            _toggle.onValueChanged.AddListener(OnChanged);
        }

        public void Clean()
        {
            _toggle.onValueChanged.RemoveListener(OnChanged);
        }

        private void OnChanged(bool added)
        {
            Debug.Log($"Add change? {added}");
            if (added)
                _statsCollection.Apply(_source, _changes);
            else
                _statsCollection.Remove(_source);
        }
    }
}
