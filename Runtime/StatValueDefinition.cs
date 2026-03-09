using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatDefinition", menuName = "Settings/Stat/ValueDefinition")]
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