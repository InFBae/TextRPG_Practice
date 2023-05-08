using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Monster
{
    internal class Scarecrow : Monster
    {
        public Scarecrow()
        {
            name = "Scarecrow";
            maxHP = 5;
            HP = maxHP;
            maxMP = 0;
            MP = maxMP;
            AP = 0;
            DP = 0;
            level = 1;           
        }
    }
}
