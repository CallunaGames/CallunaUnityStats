using System.Collections.Generic;
using System.Linq;

namespace Calluna.Stats
{
    public class Stat
    {
        public StatId Id => Definition.Id;
        public StatDefinition Definition { get; }
        public float BaseValue { get; private set; }

        public ReadonlyObservable<float> Value => _value;

        private readonly Observable<float> _value = new Observable<float>();

        private readonly Dictionary<string, List<ModifierValue>> _idToModifiers =
            new Dictionary<string, List<ModifierValue>>();

        private readonly Dictionary<string, List<PipelineLayer>> _idToLayers =
            new Dictionary<string, List<PipelineLayer>>();

        private List<PipelineLayerWithValues> _layersWithValue = new List<PipelineLayerWithValues>();
        private IOrderedEnumerable<PipelineLayer> _orderedLayers;
        private List<PipelineLayer> _layers;

        public Stat(StatDefinition definition, float baseValue)
        {
            Definition = definition;
            BaseValue = baseValue;
            _layers = definition.CalculationPipeline.Select(
                (d, i) => d.Create(i)).ToList();
            _layersWithValue.AddRange(_layers.OfType<PipelineLayerWithValues>());
            _orderedLayers = _layers.OrderBy(l => l.Priority);
        }

        public void SetModifierValue(ModifierValue modifier)
        {
            if (!_idToModifiers.TryGetValue(modifier.Source.Id, out List<ModifierValue> modifiers))
            {
                modifiers = new List<ModifierValue>();
                _idToModifiers.Add(modifier.Source.Id, modifiers);
            }

            GetLayerWithValuesFor(modifier).Add(modifier);
            CalculateValue();
        }

        public void RemoveModifierValue(ModifierValue modifier)
        {
            if (!_idToModifiers.TryGetValue(modifier.Source.Id, out List<ModifierValue> modifiers))
                return;
            modifiers.Remove(modifier);
            GetLayerWithValuesFor(modifier).Remove(modifier);
            CalculateValue();
        }

        public void RemoveAllValuesOf(ModifierSource source)
        {
            if (!_idToModifiers.Remove(source.Id, out List<ModifierValue> modifiers))
                return;
            foreach (ModifierValue modifier in modifiers)
                GetLayerWithValuesFor(modifier).Remove(modifier);
            CalculateValue();
        }

        public void SetBaseValue(float value)
        {
            BaseValue = value;
            CalculateValue();
        }

        private PipelineLayerWithValues GetLayerWithValuesFor(ModifierValue modifier)
        {
            return _layersWithValue.First(l => l.Definition == modifier.Layer);
        }

        private void CalculateValue()
        {
            float value = BaseValue;
            foreach (PipelineLayer layer in _orderedLayers)
            {
                value = layer.ApplyTo(value);
            }

            _value.Value = value;
        }
    }
}