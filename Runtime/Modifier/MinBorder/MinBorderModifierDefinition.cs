using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "MinBorder", menuName = "Calluna Games/Stats/Layers/MinBorder")]
    public class MinBorderModifierDefinition : SimplePipelineLayerDefinition
    {
        [SerializeField] private float _minBorder;
        
        public override PipelineLayer Create(int priority)
        {
            return new MinBorderLayer(this, priority);
        }

        public override float ApplyTo(float value)
        {
            return Mathf.Max(value, _minBorder);
        }
    }
}