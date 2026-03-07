using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "Factor", menuName = "Settings/Stat/Modifier/Factor")]
    public class FactorModifierDefinition : ModifierDefinition
    {
        [SerializeField] private float _value = 1;
        
        public override Modifier Create()
        {
            return new FactorModifier(CreateSource(), _value);
        }

        public override Modifier Create(ModifierSource source)
        {
            return new FactorModifier(source, _value);
        }
    }
}