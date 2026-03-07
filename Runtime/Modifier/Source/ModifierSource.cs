namespace Calluna.Stats
{
    public interface ModifierSource
    {
        public string Id { get; }
        public string Name { get; }
        public bool IsPrintable { get; }
    }
}