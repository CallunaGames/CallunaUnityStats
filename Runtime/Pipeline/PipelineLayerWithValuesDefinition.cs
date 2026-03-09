using System.Collections.Generic;

namespace Calluna.Stats
{
    public abstract class PipelineLayerWithValuesDefinition : PipelineLayerDefinition
    {
        public abstract float ApplyTo(float value, IReadOnlyCollection<ModifierValue> values);
    }
}
