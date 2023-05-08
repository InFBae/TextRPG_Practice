using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice
{
    public static class Data
    {
        public static Player.Player player;
        public static List<Monster.Monster> monsters;

        public static void Init()
        {
            player = new Player.Player();
            monsters = new List<Monster.Monster>();
        }
    }
}
