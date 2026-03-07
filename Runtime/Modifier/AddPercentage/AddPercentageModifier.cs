namespace Calluna.Stats
{
    public class AddPercentageModifier : Modifier
    {
        private readonly float _value;
        public override int Priority => 0;
        
        public AddPercentageModifier(ModifierSource source, float value) : base(source)
        {
            _value = value;
        }

        public override void ApplyTo(CalculationContext context)
        {
            context.WithAddPercentage(_value);
        }
    }
}