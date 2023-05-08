using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Monster
{
    public class Slime : Monster
    {
        public Slime()
        {
            name = "Slime";
            maxHP = 5;
            HP = maxHP;
            maxMP = 0;
            MP = maxMP;
            AP = 1;
            level = 2;
        }
    }
}
