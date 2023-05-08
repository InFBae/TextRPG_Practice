using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Scene
{
    internal class DungeonBossScene : Scene
    {
        public DungeonBossScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            this.game.PrintPlayer();

            sb.AppendLine("이곳은 던전보스방입니다.");
            sb.AppendLine("-----------------------");
            sb.AppendLine("1. 보스와 전투");
            sb.AppendLine("2. 던전으로 후퇴");

            sb.Append("\n입력 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            int index = this.game.GetInput();

            switch (index)
            {
                case 1:                  
                    Data.monsters.Add(new Monster.SlimeKing());
                    game.BattleStart();
                    break;
                case 2:
                    Console.WriteLine("던전으로 이동합니다.");
                    Thread.Sleep(1000);
                    game.MoveMap(new DungeonScene(this.game));
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
