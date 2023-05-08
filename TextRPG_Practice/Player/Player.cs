using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Practice.Player.Skill;

namespace TextRPG_Practice.Player
{
    public class Player
    {
        public string name;
        public int maxHP;
        public int HP;
        public int maxMP;
        public int MP;
        public int AP;
        public int DP;
        public string characterClass;
        public int level;
        public int maxEXP;
        public int EXP;
        public List<Skill.Skill> skills;

        public string image;

        public Player()
        {
            maxHP = 10;
            HP = maxHP;
            maxMP = 10;
            MP = maxMP;
            AP = 2;
            DP = 0;
            level = 1;
            maxEXP = 3;
            EXP = 0;

            characterClass = "Beginner";
            skills = new BeginnerSkills().SkillList;
            string imagePath = @"C:\Users\VR\source\repos\TextRPG_Practice\TextRPG_Practice\Player\모코코.txt";
            image = File.ReadAllText(imagePath);
        }

        public void TakeDamage(int damage)
        {
            if (damage > DP)
            {
                Console.WriteLine($"플레이어는 {damage - Data.player.DP} 데미지를 받았다.");
                HP -= damage - DP;
            }
            else
                Console.WriteLine($"공격은 플레이어에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (HP <= 0)
            {
                Console.WriteLine($"플레이어는 쓰려졌다!");
                Thread.Sleep(1000);

            }
        }

        public void LevelUP()
        {
            level += 1;
            maxHP += 2;
            maxMP += 2;            
            AP += 1;
            EXP = 0;
            maxEXP += (level * 2);

            FullRecovery();
        }

        public void FullRecovery()
        {
            HP = maxHP;
            MP = maxMP;
        }

        public void ClassChangeWarrior()
        {
            characterClass = "전사";
            maxHP += 5;
            AP += 3;
            skills = new WarriorSkills().SkillList;
        }
        public void ClassChangeMagician()
        {
            characterClass = "마법사";
            maxHP += 2;
            maxMP += 10;
        }
    }
}
