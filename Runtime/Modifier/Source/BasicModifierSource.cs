namespace Calluna.Stats
{
    public class BasicModifierSource : ModifierSource
    {
        public string Id { get; }

        public BasicModifierSource(string id)
        {
            Id = id;
        }
    }
}