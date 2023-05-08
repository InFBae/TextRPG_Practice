using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Player.Skill
{
    internal class BeginnerSkills
    {
        public List<Skill> SkillList;

        public BeginnerSkills()
        {
            SkillList = new List<Skill>();
            SkillList.Add(new Skill("Attack", Attack));
            SkillList.Add(new Skill("Recovery", Recovery));
        }

        public void Heal(int heal)
        {
            Data.player.HP += heal;
            if (Data.player.HP > Data.player.maxHP)
                Data.player.HP = Data.player.maxHP;
        }

        public void Attack(Monster.Monster monster)
        {
            Console.WriteLine($"플레이어가 {monster.name}(을/를) 공격한다.");
            Thread.Sleep(1000);
            monster.TakeDamage(Data.player.AP);
        }

        public void Recovery(Monster.Monster monster)
        {
            Console.WriteLine("플레이어가 회복을 시도합니다.");
            Thread.Sleep(1000);
            Heal(3);
            Data.player.MP -= 3;
            Console.WriteLine($"플레이어의 체력이 {Data.player.HP}가 되었습니다.");
            Thread.Sleep(1000);
        }

        
    }
}
