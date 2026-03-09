namespace Calluna.Stats
{
    public class NamedModifierSource : PrintableModifierSource
    {
        public string Id { get; }
        public string Name { get; }

        public NamedModifierSource(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}