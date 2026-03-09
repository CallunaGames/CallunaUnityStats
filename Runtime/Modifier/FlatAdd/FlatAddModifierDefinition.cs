using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "FlatAdd", menuName = "Settings/Stats/Layers/FlatAdd")]
    public class FlatAddModifierDefinition : PipelineLayerWithValuesDefinition
    {
        public override PipelineLayer Create(int priority)
        {
            return new FlatAddLayer(this, priority);
        }

        public override float ApplyTo(float value, IReadOnlyCollection<ModifierValue> values)
        {
            return value + values.Sum(v => v.GetValue());
        }
    }
}