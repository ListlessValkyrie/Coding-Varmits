using System;
using Foo.Abstraction;

namespace Foo.Core
{
    /// <summary>
    /// Concrete implementation of a Tamagotchi.
    /// </summary>
    public class Tamagotchi : ITamagotchi
    {
        /// <inheritdoc/>
        public int Id => throw new NotImplementedException();

        /// <inheritdoc/>
        public string Alias => throw new NotImplementedException();

        /// <inheritdoc/>
        public float Hunger => throw new NotImplementedException();

        /// <inheritdoc/>
        public float Tiredness => throw new NotImplementedException();

        /// <inheritdoc/>
        public float Bordem => throw new NotImplementedException();
    }
}
