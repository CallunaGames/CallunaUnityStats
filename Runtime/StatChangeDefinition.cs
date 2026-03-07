using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatChange", menuName = "Settings/Stat/Change")]
    public class StatChangeDefinition : ScriptableObject
    {
        [field: SerializeField] public StatId Id { get; private set; }
        [SerializeField] private List<ModifierDefinition> _modifiers = new List<ModifierDefinition>();

        public IReadOnlyList<ModifierDefinition> Modifiers => _modifiers;
    }
}