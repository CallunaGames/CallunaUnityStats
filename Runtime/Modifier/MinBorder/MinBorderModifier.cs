using UnityEngine;

namespace Calluna.Stats
{
    public class MinBorderModifier : Modifier
    {
        private readonly float _value;

        public override int Priority => int.MinValue;
        
        public MinBorderModifier(ModifierSource source, float value) : base(source)
        {
            _value = value;
        }
        
        public override void ApplyTo(CalculationContext context)
        {
            context.WithEndValueModifier(f => Mathf.Max(f, _value));
        }
    }
}