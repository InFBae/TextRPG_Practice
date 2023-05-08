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
        public BattleScene(Game game) : base(game)
        {  
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            this.game.PrintPlayer();

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
                Console.WriteLine("전투종료");
                Thread.Sleep(1000);
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
    }
}
