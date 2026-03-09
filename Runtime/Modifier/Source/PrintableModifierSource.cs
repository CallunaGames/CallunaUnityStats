namespace Calluna.Stats
{
    public interface PrintableModifierSource : ModifierSource
    {
        public string Name { get; }
        public bool IsPrintable { get; }
    }
}