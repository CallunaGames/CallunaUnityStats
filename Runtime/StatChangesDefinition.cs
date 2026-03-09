using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatChange", menuName = "Calluna Games/Stats/Change")]
    public class StatChangesDefinition : ScriptableObject
    {
        [SerializeField] private List<ModiferValueDefinition> _modifiers = new List<ModiferValueDefinition>();

        public IReadOnlyList<ModiferValueDefinition> Modifiers => _modifiers;
    }
}