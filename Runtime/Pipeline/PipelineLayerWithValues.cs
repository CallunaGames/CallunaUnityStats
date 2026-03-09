using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    public class PipelineLayerWithValues : PipelineLayer
    {
        private List<ModifierValue> _values = new List<ModifierValue>();
        private PipelineLayerWithValuesDefinition _definition;

        public PipelineLayerWithValues(PipelineLayerWithValuesDefinition definition, int priority) : base(definition, priority)
        {
            _definition = definition;
        }

        public void Add(ModifierValue modifier)
        {
            _values.Add(modifier);
        }

        public void Remove(ModifierValue modifier)
        {
            _values.Remove(modifier);
        }

        public override float ApplyTo(float value)
        {
            return _definition.ApplyTo(value, _values.AsReadOnly());
        }
    }
}
