using System;

namespace Calluna.Stats
{
    public abstract class PipelineLayerDefinition : ScriptableObjectId, IEquatable<PipelineLayerDefinition>
    {
        public bool Equals(PipelineLayerDefinition other)
        {
            return ReferenceEquals(other, this);
        }

        public abstract PipelineLayer Create(int priority);
    }
}