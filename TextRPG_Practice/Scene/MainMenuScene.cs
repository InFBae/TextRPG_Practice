using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_Practice.Scene
{
    internal class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 게임 시작");
            sb.AppendLine("2. 게임 종료");
            sb.Append("\n입력 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            int index = this.game.GetInput();

            switch (index)
            {
                case 1:
                    game.GameStart();
                    break;
                case 2:
                    game.GameOver("게임을 종료했습니다.");
                    break;
                default:
                    Console.WriteLine("잘못 입력 하셨습니다.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }
}
