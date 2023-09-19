using OpenRpg.Core.Classes;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Races;
using OpenRpg.Core.Utils;
using OpenRpg.Data;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.Builders;
using OpenRpg.Genres.Characters;
using OpenRpg.Genres.Extensions;
using OpenRpg.Genres.Fantasy.Extensions;
using OpenRpg.Genres.Persistence.Characters;
using RandomNameGenerator;

namespace OpenRpg.Demos.Infrastructure.Builders
{
    public class DemoCharacterBuilder : CharacterBuilder
    {
        public IRepository Repository { get; }

        public DemoCharacterBuilder(ICharacterMapper characterMapper, IRandomizer randomizer, IRepository repository) : base(characterMapper, randomizer)
        {
            Repository = repository;
        }

        protected override void RandomizeDefaults()
        {
            var raceData = Repository.GetAll<IRaceTemplate>();
            var classData = Repository.GetAll<IClassTemplate>();
            
            if (_raceId == 0) { _raceId = Randomizer.TakeRandomFrom(raceData).Id; }
            if (_classId == 0) { _classId = Randomizer.TakeRandomFrom(classData).Id; }
            if (_genderId == 0) { _genderId = (byte)Randomizer.Random(1,2); }
            if (_classLevels == 0) { _classLevels = Randomizer.Random(1,5); }
            if (string.IsNullOrEmpty(_name)) { _name = NameGenerator.Generate(_genderId == 1 ? Gender.Male : Gender.Female); }
        }

        protected override void PostProcessCharacter(ICharacter character)
        {
            var health = character.Stats.MaxHealth();
            var magic = character.Stats.MaxMagic();
            character.State.Health(health);
            character.State.Magic(magic);
        }
    }
}