namespace Calluna.Stats
{
    public class NonPrintableModifierSource : ModifierSource
    {
        public string Id { get; }
        public string Name => string.Empty;
        public bool IsPrintable => false;

        public NonPrintableModifierSource(string id)
        {
            Id = id;
        }
    }
}