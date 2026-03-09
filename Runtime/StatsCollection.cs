using System.Collections.Generic;

namespace Calluna.Stats
{
    public class StatsCollection
    {
        private readonly Dictionary<StatId, Stat> _stats = new Dictionary<StatId, Stat>();
        public IEnumerable<Stat> Stats => _stats.Values;

        public static StatsCollection Create(IEnumerable<Stat> stats)
        {
            StatsCollection collection = new StatsCollection();
            foreach (Stat stat in stats)
            {
                collection.Add(stat);
            }
            return collection;
        }

        public static StatsCollection Create(IEnumerable<StatValueDefinition> stats)
        {
            StatsCollection collection = new StatsCollection();
            foreach (StatValueDefinition stat in stats)
            {
                collection.Add(stat.Create());
            }
            return collection;
        }
        
        public void Add(Stat stat)
        {
            _stats.Add(stat.Id, stat);
        }

        public void Apply(ModifierSource source, StatChangesDefinition statChanges)
        {
            foreach (ModiferValueDefinition definition in statChanges.Modifiers)
            {
                Stat stat = _stats[definition.StatId];
                stat.SetModifierValue(definition.Create(source));
            }
        }

        public void Remove(ModifierSource source)
        {
            foreach (Stat stat in _stats.Values)
            {
                stat.RemoveAllValuesOf(source);
            }
        }

        public Stat this[StatId id] => _stats[id];
    }
}