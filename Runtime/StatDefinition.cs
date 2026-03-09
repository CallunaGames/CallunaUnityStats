using System.Collections.Generic;
using UnityEngine;

namespace Calluna.Stats
{
    [CreateAssetMenu(fileName = "StatDefinition", menuName = "Settings/Stat/Definition")]
    public class StatDefinition : ScriptableObject
    {
        [field: SerializeField] public StatId Id { get; private set; }
        [SerializeField] private List<PipelineLayerDefinition> _calculationPipeline = new List<PipelineLayerDefinition>();

        public IReadOnlyList<PipelineLayerDefinition> CalculationPipeline => _calculationPipeline;
    }
}
