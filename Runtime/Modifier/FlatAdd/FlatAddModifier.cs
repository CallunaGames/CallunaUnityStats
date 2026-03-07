namespace Calluna.Stats
{
    public class FlatAddModifier : Modifier
    {
        public override int Priority => 0;
        private readonly float _value;
        
        public FlatAddModifier(ModifierSource source, float value) : base(source)
        {
            _value = value;
        }
        
        public override void ApplyTo(CalculationContext context)
        {
            context.AddFlat(_value);
        }
    }
}