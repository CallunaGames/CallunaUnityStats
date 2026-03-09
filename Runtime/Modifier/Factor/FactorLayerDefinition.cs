using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "Factor", menuName = "Calluna Games/Stats/Layers/Factor")]
    public class FactorLayerDefinition : PipelineLayerWithValuesDefinition
    {
        public override PipelineLayer Create(int priority)
        {
            return new FactorLayer(this, priority);
        }

        public override float ApplyTo(float value, IReadOnlyCollection<ModifierValue> values)
        {
            float factor = 1;
            foreach (ModifierValue modifierValue in values)
            {
                factor *= modifierValue.GetValue();
            }
            return value * factor;
        }
    }
}