namespace Calluna.Stats
{
    public abstract class PipelineLayer
    {
        public PipelineLayerDefinition Definition { get; private set; }
        public float Priority { get; private set; }
        
        public PipelineLayer(PipelineLayerDefinition definition, float priority)
        {
            Definition = definition;
            Priority = priority;
        }

        public abstract float ApplyTo(float value);
    }
}