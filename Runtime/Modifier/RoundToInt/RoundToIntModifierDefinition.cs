using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "RoundToInt", menuName = "Settings/Stat/Modifier/RoundToInt")]
    public class RoundToIntModifierDefinition : ModifierDefinition
    {
        public override Modifier Create()
        {
            return new RoundToIntModifier(CreateSource());
        }

        public override Modifier Create(ModifierSource source)
        {
            return new RoundToIntModifier(source);
        }
    }
}