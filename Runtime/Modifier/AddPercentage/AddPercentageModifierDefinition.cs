using UnityEngine;

namespace Calluna.Stats
{
    public class AddPercentageModifierDefinition : ModifierDefinition
    {
        [SerializeField] private float _value = 0;
        
        public override Modifier Create()
        {
            return new AddPercentageModifier(CreateSource(), _value);
        }

        public override Modifier Create(ModifierSource source)
        {
            return new AddPercentageModifier(source, _value);
        }
    }
}