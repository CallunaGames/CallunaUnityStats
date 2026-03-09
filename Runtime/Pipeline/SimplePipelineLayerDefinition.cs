namespace Calluna.Stats
{
    public abstract class SimplePipelineLayerDefinition : PipelineLayerDefinition
    {
        public abstract float ApplyTo(float value);
    }
}