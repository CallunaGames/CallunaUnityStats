namespace Calluna.Stats
{
    public class FactorModifier : Modifier
    {
        private readonly float _value;
        public override int Priority => 0;
        
        public FactorModifier(ModifierSource source, float value) : base(source)
        {
            _value = value;
        }

        public override void ApplyTo(CalculationContext context)
        {
            context.WithFactor(_value);
        }
    }
}