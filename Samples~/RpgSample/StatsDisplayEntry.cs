using Calluna.DI;
using TMPro;
using UnityEngine;

namespace Calluna.Stats.Samples.Rpg
{
    public class StatsDisplayEntry : MonoBehaviour, Injectable, Initializable, Cleanable
    {
        [SerializeField] private TextMeshProUGUI _text;
        private Stat _stat;
        
        public void Inject(Resolver resolver)
        {
            _stat = resolver.Resolve<Stat>();
        }

        public void Initialize()
        {
            _stat.Value.OnChanged += UpdateText;
            UpdateText();
        }

        public void Clean()
        {
            _stat.Value.OnChanged -= UpdateText;
        }

        private void UpdateText()
        {
            _text.text = $"{_stat.Id.Id}: {_stat.Value.Value}";
        }
    }
}
