using System.Linq;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Races;
using OpenRpg.Core.Stats;
using OpenRpg.Core.Utils;
using OpenRpg.Demos.Infrastructure.Data;
using OpenRpg.Genres.Characters;
using OpenRpg.Genres.Extensions;
using OpenRpg.Items.Equipment;
using RandomNameGenerator;

namespace OpenRpg.Demos.Infrastructure.Builders
{
    public class CharacterBuilder
    {
        public RaceRepository RaceRepository { get; }
        public ClassRepository ClassRepository { get; }
        public IStatsComputer StatsComputer { get; }
        public IRandomizer Randomizer { get; }

        private int _raceId, _classId, _classLevels, _genderId;
        private string _name;
        private static int currentId;

        public CharacterBuilder(RaceRepository raceRepository, ClassRepository classRepository, IStatsComputer statsComputer, IRandomizer randomizer)
        {
            RaceRepository = raceRepository;
            ClassRepository = classRepository;
            StatsComputer = statsComputer;
            Randomizer = randomizer;
        }

        public CharacterBuilder CreateNew()
        {
            _raceId = _classId = _classLevels = _genderId = 0;
            _name = string.Empty;
            return this;
        }

        public CharacterBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CharacterBuilder WithRaceId(int raceId)
        {
            _raceId = raceId;
            return this;
        }

        public CharacterBuilder WithRace(IRaceTemplate race)
        { return WithRaceId(race.Id); }

        public CharacterBuilder WithClassId(int classId)
        {
            _classId = classId;
            return this;
        }

        public CharacterBuilder WithClass(IClassTemplate classTemplate)
        { return WithClassId(classTemplate.Id); }

        public CharacterBuilder WithClassLevels(int levels)
        {
            _classLevels = levels;
            return this;
        }

        public CharacterBuilder AsMale()
        {
            _genderId = 1;
            return this;
        }

        public CharacterBuilder AsFemale()
        {
            _genderId = 2;
            return this;
        }

        public DefaultCharacter Build()
        {
            if (_raceId == 0) { _raceId = Randomizer.TakeRandomFrom(RaceRepository.Data).Id; }
            if (_classId == 0) { _classId = Randomizer.TakeRandomFrom(ClassRepository.Data).Id; }
            if (_genderId == 0) { _genderId = Randomizer.Random(1,2); }
            if (_classLevels == 0) { _classLevels = Randomizer.Random(1,5); }
            
            if (string.IsNullOrEmpty(_name))
            { _name = NameGenerator.Generate(_genderId == 1 ? Gender.Male : Gender.Female); }

            var character = new DefaultCharacter
            {
                Id = ++currentId,
                NameLocaleId = _name,
                Race = RaceRepository.Retrieve(_raceId),
                Class = new DefaultClass(_classLevels, ClassRepository.Retrieve(_classId)),
                GenderType = (byte)_genderId,
                Equipment = new DefaultEquipment()
            };

            character.Stats = StatsComputer.ComputeStats(character.GetEffects().ToArray());
            return character;
        }
    }
}