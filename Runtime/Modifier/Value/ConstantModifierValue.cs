namespace Calluna.Stats
{
    public class ConstantModifierValue : ModifierValue
    {
        public override PipelineLayerWithValuesDefinition Layer { get; }
        public override ModifierSource Source { get; }
        private float _value;
        
        public ConstantModifierValue(float value, PipelineLayerWithValuesDefinition layer,
            ModifierSource source)
        {
            Layer = layer;
            Source = source;
            _value = value;
        }

        public override float GetValue()
        {
            return _value;
        }
    }
}