using UnityEngine;

namespace Calluna.Stats
{
    public abstract class ModifierDefinition : ScriptableObject
    {
        public abstract Modifier Create();

        public abstract Modifier Create(ModifierSource source);

        protected ModifierSource CreateSource() => new NonPrintableModifierSource(GetInstanceID().ToString());
    }
}