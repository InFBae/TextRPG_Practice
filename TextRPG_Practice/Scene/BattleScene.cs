using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Scene
{
    
    public class BattleScene : Scene
    {
        private Monster.Monster monster;
        private Scene previousScene;
        public BattleScene(Game game, Scene previousScene) : base(game)
        {  
            this.previousScene = previousScene;
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            PrintBattleScene();

            sb.AppendLine();
            sb.AppendLine("-----------------------");
            for(int i = 0; i < Data.player.skills.Count; i++)
            {
                sb.AppendLine($"{i+1}. {Data.player.skills[i].name}");
            }

            sb.Append("\n입력 : ");

            Console.Write(sb.ToString());

        }

        public override void Update()
        {
            int index = this.game.GetInput();
            if (index < 1 || index > Data.player.skills.Count)
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                return;
            }
            Data.player.skills[index - 1].action(monster);
            
            // 턴 결과
            if (monster.HP <= 0)
            {
                Console.Clear();
                Console.WriteLine("전투종료");
                Thread.Sleep(1000);
                Data.player.EXP += monster.level;
                Console.WriteLine($"플레이어가 {monster.level}의 경험치를 얻었습니다.");
                Thread.Sleep(1000);
                if(Data.player.EXP >= Data.player.maxEXP) 
                { 
                    Console.WriteLine("레벨 업");
                    Thread.Sleep(1000);
                    Data.player.LevelUP(); 
                }
                game.MoveMap(previousScene);
                return;
            }

            // 몬스터 턴
            monster.Attack(Data.player);

            // 턴 결과
            if (Data.player.HP <= 0)
            {
                game.GameOver("몬스터에게 패배했습니다.");
                return;
            }
        }

        public void StartBattle(Monster.Monster monster)
        {
            this.monster = monster;
            Data.monsters.RemoveAt(0);

            Console.Clear();
            Console.WriteLine($"{monster.name}(와/과) 전투 시작!");
            Thread.Sleep(1000);
        }
        public void PrintBattleScene()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"이름 : {Data.player.name}");
            sb.Append($"\t\t이름 : {monster.name}\n");
            sb.Append($"HP : {Data.player.HP}/{Data.player.maxHP}");
            sb.Append($"\t\tHP : {monster.HP}/{monster.maxHP}\n");
            sb.Append($"MP : {Data.player.MP}/{Data.player.maxMP}");
            sb.Append($"\t\tMP : {monster.MP}/{monster.maxMP}");

            Console.WriteLine(sb.ToString());

        }
    }
}
