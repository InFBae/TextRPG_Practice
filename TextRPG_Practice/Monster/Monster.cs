using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Monster
{
    public abstract class Monster 
    {
        public string name;
        public int maxHP;
        public int HP;
        public int maxMP;
        public int MP;
        public int AP;
        public int DP;
        public int level;


        public void TakeDamage(int damage)
        {
            if (damage > DP)
            {
                Console.WriteLine($"{name}은/는 {damage - DP} 데미지를 받았다.");
                HP -= damage - DP;
            }
            else
                Console.WriteLine($"공격은 {name}에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (HP <= 0)
            {
                Console.WriteLine($"{name}은/는 쓰려졌다!");
                Thread.Sleep(1000);

            }
        }

        public void Attack(Player.Player player)
        {

            Console.WriteLine($"{name}이/가 {player.name}(을/를) 공격한다.");
            Thread.Sleep(1000);
            player.TakeDamage(AP);
        }
    }

}
