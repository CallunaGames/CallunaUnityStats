using System;
using System.Collections.Generic;

namespace Calluna.Stats
{
    public sealed class CalculationContext
    {
        private readonly float _baseValue;
        private float _flat;
        private float _addPercentage;
        private float _factor;
        private float? _override;
        private List<Func<float, float>> _endValueModifications;

        public CalculationContext(float baseValue)
        {
            _baseValue = baseValue;
        }

        public void AddFlat(float value)
        {
            _flat += value;
        }

        public void WithAddPercentage(float value)
        {
            _addPercentage += value;
        }

        public void WithFactor(float value)
        {
            _factor += value;
        }

        public void WithOverride(float value)
        {
            _override = value;
        }

        public void WithEndValueModifier(Func<float, float> modifier)
        {
            _endValueModifications.Add(modifier);
        }

        public float Calculate()
        {
            if (_override.HasValue)
                return _override.Value;
            float value = (_baseValue + _flat) * (1f + _addPercentage) * _factor;
            foreach (Func<float,float> func in _endValueModifications)
            {
                value = func(value);
            }
            return value;
        }
    }
}