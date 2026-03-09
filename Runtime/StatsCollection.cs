using System.Collections.Generic;

namespace Calluna.Stats
{
    public class StatsCollection
    {
        private readonly Dictionary<StatId, Stat> _stats = new Dictionary<StatId, Stat>();

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

        public void Apply(ModifierSource source, StatChangeDefinition statChange)
        {
            Stat stat = _stats[statChange.Id];

            foreach (ModiferValueDefinition definition in statChange.Modifiers)
            {
                stat.SetModifierValue(definition.Create(source));
            }
        }

        public void Apply(ModifierSource source, IEnumerable<StatChangeDefinition> statChanges)
        {
            foreach (StatChangeDefinition statChange in statChanges)
            {
                Apply(source, statChange);
            }
        }

        public Stat this[StatId id] => _stats[id];
    }
}