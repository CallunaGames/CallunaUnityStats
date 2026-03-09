using System.Collections;
using Calluna.DI;
using UnityEngine;
using UnityEngine.UI;

namespace Calluna.Stats.Samples.Rpg
{
    public class AddTempBuffButton : MonoBehaviour, Injectable, Initializable, Cleanable
    {
        [SerializeField] private Button _button;
        [SerializeField] private StatChangesDefinition _changes;
        [SerializeField] private float _buffDuration = 3;
        [SerializeField] private string _name;
        [SerializeField] private Image _durationView;

        private StatsCollection _collection;
        private Coroutine _routine;
        private NamedModifierSource _source;
        private float _time;

        public void Inject(Resolver resolver)
        {
            _collection = resolver.Resolve<StatsCollection>();
            _source = new NamedModifierSource(GetInstanceID().ToString(), _name);
        }

        public void Initialize()
        {
            _button.onClick.AddListener(OnClick);
            _time = 0;
            _durationView.fillAmount = 0;
        }

        private void Update()
        {
            _button.interactable = _routine == null;
            if (_routine != null)
                _durationView.fillAmount = 1 - (Time.time - _time) / _buffDuration;
        }

        public void Clean()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _routine = StartCoroutine(AddBuff());
        }

        private IEnumerator AddBuff()
        {
            _time = Time.time;
            _collection.Apply(_source, _changes);
            yield return new WaitForSeconds(_buffDuration);
            _collection.Remove(_source);
            _routine = null;
        }
    }
}
