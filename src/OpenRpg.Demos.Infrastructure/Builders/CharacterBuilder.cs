using System.Linq;
using OpenRpg.Core.Classes;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Races;
using OpenRpg.Core.Stats;
using OpenRpg.Core.Utils;
using OpenRpg.Data;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.Characters;
using OpenRpg.Genres.Extensions;
using RandomNameGenerator;

namespace OpenRpg.Demos.Infrastructure.Builders
{
    public class CharacterBuilder
    {
        public IRepository Repository { get; }
        public IStatsComputer StatsComputer { get; }
        public IRandomizer Randomizer { get; }

        private int _raceId, _classId, _classLevels, _genderId;
        private string _name;
        private static int currentId;

        public CharacterBuilder(IRepository repository, IStatsComputer statsComputer, IRandomizer randomizer)
        {
            Repository = repository;
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
            var raceData = Repository.GetAll<IRaceTemplate>();
            var classData = Repository.GetAll<IClassTemplate>();
            
            if (_raceId == 0) { _raceId = Randomizer.TakeRandomFrom(raceData).Id; }
            if (_classId == 0) { _classId = Randomizer.TakeRandomFrom(classData).Id; }
            if (_genderId == 0) { _genderId = Randomizer.Random(1,2); }
            if (_classLevels == 0) { _classLevels = Randomizer.Random(1,5); }
            
            if (string.IsNullOrEmpty(_name))
            { _name = NameGenerator.Generate(_genderId == 1 ? Gender.Male : Gender.Female); }

            var character = new DefaultCharacter
            {
                Id = ++currentId,
                NameLocaleId = _name,
                Race = Repository.Get<IRaceTemplate>(_raceId),
                Class = new DefaultClass(_classLevels, Repository.Get<IClassTemplate>(_classId)),
                GenderType = (byte)_genderId
            };

            character.Stats = StatsComputer.ComputeStats(character.GetEffects().ToArray());
            return character;
        }
    }
}