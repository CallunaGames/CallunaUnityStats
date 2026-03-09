using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "RoundToInt", menuName = "Calluna Games/Stats/Layers/RoundToInt")]
    public class RoundToIntModifierDefinition : SimplePipelineLayerDefinition
    {
        public override PipelineLayer Create(int priority)
        {
            return new RoundToIntModifier(this, priority);
        }

        public override float ApplyTo(float value)
        {
            return Mathf.RoundToInt(value);
        }
    }
}