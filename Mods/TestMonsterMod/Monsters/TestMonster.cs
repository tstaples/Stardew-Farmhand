﻿using Farmhand.API.Monsters;
using Microsoft.Xna.Framework;

namespace TestMonsterMod.Monsters
{
    class TestMonster : Farmhand.Overrides.Character.Monster
    {

        public TestMonster(MonsterInformation Information, Vector2 Position)
            : base(Information, Position)
        {

        }
    }
}
