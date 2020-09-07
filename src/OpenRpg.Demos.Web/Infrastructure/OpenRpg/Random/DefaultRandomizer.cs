using OpenRpg.Core.Utils;

namespace OpenRpg.Demos.Web.Infrastructure.OpenRpg.Random
{
    public class DefaultRandomizer : IRandomizer
    {
        private System.Random _random;

        public DefaultRandomizer(System.Random random)
        {
            _random = random;
        }

        public int Random(int min, int max)
        { return _random.Next(min, max); }

        public float Random(float min, float max)
        { return (float)_random.NextDouble() * (max - min) + min; }
    }
}