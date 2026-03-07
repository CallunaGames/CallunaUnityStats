using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatDefinition", menuName = "Settings/Stat/ValueDefinition")]
    public class StatValueDefinition : ScriptableObject
    {
        [field: SerializeField] public StatDefinition Definition { get; private set; }
        [field: SerializeField] public float BaseValue { get; private set; }
        [SerializeField] private List<ModifierDefinition> _modifiers = new List<ModifierDefinition>();

        public Stat Create()
        {
            Stat stat = new Stat(Definition, BaseValue);
            foreach (ModifierDefinition modifier in GetModifiers())
            {
                stat.SetModifier(modifier.Create());
            }
            return stat;
        }

        private IEnumerable<ModifierDefinition> GetModifiers()
        {
            foreach (ModifierDefinition modifier in Definition.Modifiers)
            {
                yield return modifier;
            }

            foreach (ModifierDefinition modifier in _modifiers)
            {
                yield return modifier;
            }
        }
    }
}