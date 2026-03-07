using UnityEngine;

namespace Calluna.Stats
{
    public class RoundToIntModifier : Modifier
    {
        public override int Priority => 0;
        
        public RoundToIntModifier(ModifierSource source) : base(source)
        {
            
        }

        public override void ApplyTo(CalculationContext context)
        {
            context.WithEndValueModifier(f => Mathf.RoundToInt(f));
        }
    }
}