using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Monster
{
    internal class SlimeKing : Slime
    {
        public SlimeKing()
        {
            name = "SlimeKing";
            maxHP = 15;
            HP = maxHP;
            maxMP = 0;
            MP = maxMP;
            AP = 3;
            level = 3;
            DP = 2;
        }
    }
}
