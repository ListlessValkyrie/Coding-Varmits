namespace Foo.Abstraction
{
    /// <summary>
    /// Egg Watch!.
    /// </summary>
    public interface ITamagotchi
    {
        /// <summary>
        /// Gets unique identifier.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Gets the name of your terrible digital pet.
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Gets how hungry the critter is.
        /// </summary>
        float Hunger { get; }

        /// <summary>
        /// Gets how tired the critter is.
        /// </summary>
        float Tiredness { get; }

        /// <summary>
        /// Gets how bored the critter is.
        /// </summary>
        float Bordem { get; }
    }
}
