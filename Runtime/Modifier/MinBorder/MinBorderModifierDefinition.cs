using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "MinBorder", menuName = "Settings/Stat/Modifier/MinBorder")]
    public class MinBorderModifierDefinition : ModifierDefinition
    {
        [SerializeField] private float _minBorder;
        
        public override Modifier Create()
        {
            return new MinBorderModifier(CreateSource(), _minBorder);
        }

        public override Modifier Create(ModifierSource source)
        {
            return new MinBorderModifier(source, _minBorder);
        }
    }
}