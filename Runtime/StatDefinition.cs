using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatDefinition", menuName = "Settings/Stat/Definition")]
    public class StatDefinition : ScriptableObject
    {
        [field: SerializeField] public StatId Id { get; private set; }
        [SerializeField] private List<ModifierDefinition> _modifiers = new List<ModifierDefinition>();
        
        public IReadOnlyList<ModifierDefinition> Modifiers => _modifiers;
    }
}
