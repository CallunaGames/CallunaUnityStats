using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatValue", menuName = "Calluna Games/Stats/StatValue")]
    public class StatValueDefinition : ScriptableObject
    {
        [field: SerializeField] public StatDefinition Definition { get; private set; }
        [field: SerializeField] public float BaseValue { get; private set; }

        public Stat Create()
        {
            return new Stat(Definition, BaseValue);
        }
    }
}