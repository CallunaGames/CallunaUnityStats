using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "FlatAdd", menuName = "Settings/Stat/Modifier/FlatAdd")]
    public class FlatAddModifierDefinition : ModifierDefinition
    {
        [SerializeField] private float _value;
        
        public override Modifier Create()
        {
            return new FlatAddModifier(CreateSource(), _value);
        }

        public override Modifier Create(ModifierSource source)
        {
            return new FlatAddModifier(source, _value);
        }
    }
}