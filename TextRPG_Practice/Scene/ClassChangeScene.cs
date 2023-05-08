using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Scene
{
    internal class ClassChangeScene : Scene
    {
        public ClassChangeScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            this.game.PrintPlayer();

            sb.AppendLine("이곳은 전직소입니다.");
            sb.AppendLine("-----------------------");
            sb.AppendLine("1. 전사로 전직");
            sb.AppendLine("2. 마법사로 전직");
            sb.AppendLine("3. 마을로 이동");


            sb.Append("\n입력 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            int index = this.game.GetInput();

            switch (index)
            {
                case 1:
                    if(Data.player.level < 3)
                    {
                        Console.WriteLine("레벨이 부족합니다.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Data.player.ClassChangeWarrior();
                    }
                    break;
                case 2:
                    if (Data.player.level < 3)
                    {
                        Console.WriteLine("레벨이 부족합니다.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Data.player.ClassChangeMagician();
                    }
                    break;
                case 3:
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
