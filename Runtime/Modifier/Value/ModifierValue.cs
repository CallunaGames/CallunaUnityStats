using UnityEngine;

namespace Calluna.Stats
{
    public abstract class ModifierValue
    {
        public abstract ModifierSource Source { get; }
        public abstract PipelineLayerWithValuesDefinition Layer { get; }
        public abstract float GetValue();
    }
}
