using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "ConstantModifierValue", menuName = "Settings/Stat/Values/Constant")]
    public class ConstantModifierValueDefinition : ModiferValueDefinition
    {
        [field: SerializeField] public float Value { get; private set; }

        public override ModifierValue Create(ModifierSource source)
        {
            return new ConstantModifierValue(Value, Layer, source);
        }
    }
}