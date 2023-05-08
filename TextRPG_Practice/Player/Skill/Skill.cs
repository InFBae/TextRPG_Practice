using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Player.Skill
{
    public struct Skill
    {
        public string name;
        public Action<Monster.Monster> action;

        public Skill(string name, Action<Monster.Monster> action)
        {
            this.name = name;
            this.action = action;
        }
    }
}
