using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "AddPercentage", menuName = "Settings/Stats/Layers/AddPercentage")]
    public class AddPercentageLayerDefinition : PipelineLayerWithValuesDefinition
    {
        public override PipelineLayer Create(int priority)
        {
            return new AddPercentageLayer(this, priority);
        }

        public override float ApplyTo(float value, IReadOnlyCollection<ModifierValue> values)
        {
            return value * (1f + values.Sum(v => v.GetValue()));
        }
    }
}