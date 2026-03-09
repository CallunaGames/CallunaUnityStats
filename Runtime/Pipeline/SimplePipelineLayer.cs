namespace Calluna.Stats
{
    public class SimplePipelineLayer : PipelineLayer
    {
        private SimplePipelineLayerDefinition _simpleDefinition;
        
        public SimplePipelineLayer(SimplePipelineLayerDefinition definition, int priority) : base(definition, priority)
        {
            _simpleDefinition = definition;
        }

        public override float ApplyTo(float value)
        {
            return _simpleDefinition.ApplyTo(value);
        }
    }
}