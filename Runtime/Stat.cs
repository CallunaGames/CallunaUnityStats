using System.Collections.Generic;
using System.Linq;

namespace Calluna.Stats
{
    public class Stat
    {
        public StatId Id => Definition.Id;
        public StatDefinition Definition { get; }
        public float BaseValue { get; private set; }
        
        private float _value;
        private bool _isDirty = true;
        private readonly Dictionary<string, List<Modifier>> _idToModifiers = new Dictionary<string, List<Modifier>>();
        private IOrderedEnumerable<Modifier> _orderedModifiers = Enumerable.Empty<Modifier>().OrderBy(m => m.Priority);
        
        public Stat(StatDefinition definition, float baseValue)
        {
            Definition = definition;
            BaseValue = baseValue;
        }

        public void SetModifier(Modifier modifier)
        {
            if (!_idToModifiers.TryGetValue(modifier.Source.Id, out List<Modifier> modifiers))
            {
                modifiers = new List<Modifier>();
                _idToModifiers.Add(modifier.Source.Id, modifiers);
            }
            modifiers.Add(modifier);
            OrderModifiers();
            _isDirty = true;
        }

        public void RemoveModifier(Modifier modifier)
        {
            if(!_idToModifiers.TryGetValue(modifier.Source.Id, out List<Modifier> modifiers))
                return;
            modifiers.Remove(modifier);
            OrderModifiers();
            _isDirty = true;
        }

        public float GetValue()
        {
            if (_isDirty)
                CalculateValue();
            return _value;
        }

        public void SetBaseValue(float value)
        {
            BaseValue = value;
            _isDirty = true;
        }

        private void CalculateValue()
        {
            _isDirty = false;
            CalculationContext context = new CalculationContext(BaseValue);
            foreach (Modifier modifier in _orderedModifiers)
            {
                modifier.ApplyTo(context);
            }
            _value = context.Calculate();
        }

        private void OrderModifiers()
        {
            _orderedModifiers = GetAllModifiers().OrderByDescending(m => m.Priority);
        }

        private IEnumerable<Modifier> GetAllModifiers()
        {
            foreach (List<Modifier> modifiers in _idToModifiers.Values)
            {
                foreach (Modifier modifier in modifiers)
                {
                    yield return modifier;
                }
            }
        }
    }
}