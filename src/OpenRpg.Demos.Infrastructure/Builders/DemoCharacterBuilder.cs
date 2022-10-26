﻿using OpenRpg.Core.Classes;
using OpenRpg.Core.Extensions;
using OpenRpg.Core.Races;
using OpenRpg.Core.Utils;
using OpenRpg.Data;
using OpenRpg.Data.Conventions.Extensions;
using OpenRpg.Genres.Builders;
using OpenRpg.Genres.Persistence.Characters;

namespace OpenRpg.Demos.Infrastructure.Builders
{
    public class DemoCharacterBuilder : CharacterBuilder
    {
        public IRepository Repository { get; }

        protected DemoCharacterBuilder(ICharacterMapper characterMapper, IRandomizer randomizer, IRepository repository) : base(characterMapper, randomizer)
        {
            Repository = repository;
        }

        public override void RandomzieDefaults()
        {
            var raceData = Repository.GetAll<IRaceTemplate>();
            var classData = Repository.GetAll<IClassTemplate>();
            
            if (_raceId == 0) { _raceId = Randomizer.TakeRandomFrom(raceData).Id; }
            if (_classId == 0) { _classId = Randomizer.TakeRandomFrom(classData).Id; }
            if (_genderId == 0) { _genderId = Randomizer.Random(1,2); }
            if (_classLevels == 0) { _classLevels = Randomizer.Random(1,5); }
        }
    }
}