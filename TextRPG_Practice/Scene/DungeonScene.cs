using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Scene
{
    internal class DungeonScene : Scene
    {
        public DungeonScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            this.game.PrintPlayer();

            sb.AppendLine("이곳은 던전입니다.");
            sb.AppendLine("-----------------------");
            sb.AppendLine("1. 진행");
            sb.AppendLine("2. 마을로 귀환");

            sb.Append("\n입력 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            int index = this.game.GetInput();

            switch (index)
            {
                case 1:
                    Data.monsters.Add(new Monster. Slime());
                    game.BattleStart();
                    break;
                case 2:
                    Console.WriteLine("마을로 이동합니다.");
                    Thread.Sleep(1000);
                    game.MoveMap(new StartVillageScene(this.game));
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
