namespace Calluna.Stats
{
    public abstract class Modifier
    {
        public ModifierSource Source { get; }
        public abstract int Priority { get; }

        public Modifier(ModifierSource source)
        {
            Source = source;
        }
        
        public abstract void ApplyTo(CalculationContext context);
    }
}