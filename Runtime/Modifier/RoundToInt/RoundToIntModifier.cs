using UnityEngine;

namespace Calluna.Stats
{
    public class RoundToIntModifier : SimplePipelineLayer
    {
        public RoundToIntModifier(SimplePipelineLayerDefinition definition, int priority) : base(definition, priority)
        {
        }
    }
}