using UnityEngine;

namespace Calluna.Stats
{
    public abstract class ModiferValueDefinition : ScriptableObject
    {
        [field: SerializeField] public StatId StatId { get; private set; }
        [field: SerializeField] public PipelineLayerWithValuesDefinition Layer { get; private set; }

        public abstract ModifierValue Create(ModifierSource source);
    }
}