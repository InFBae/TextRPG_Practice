using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Player.Skill
{
    internal class WarriorSkills : BeginnerSkills
    {
        public WarriorSkills()
        {
            SkillList = new List<Skill>();
            SkillList.Add(new Skill("Attack", Attack));
            SkillList.Add(new Skill("Recovery", Recovery));
            SkillList.Add(new Skill("DoubleAttack", DoubleAttack));
        }

        public void DoubleAttack(Monster.Monster monster)
        {
            Console.WriteLine("플레이어가 더블어택을 시도합니다.");
            Thread.Sleep(1000);
            if (Data.player.MP >= 2)
            {
                Data.player.MP -= 2;

                Console.WriteLine($"플레이어가 {monster.name}(을/를) 두 번 공격한다.");
                Thread.Sleep(1000);
                monster.TakeDamage(Data.player.AP);
                monster.TakeDamage(Data.player.AP);
            }
            else
            {
                Console.WriteLine($"MP가 부족하여 스킬시전에 실패했습니다.");
                Thread.Sleep(1000);
            }         
        }
    }
}
