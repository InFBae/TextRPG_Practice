using System.Text;

namespace TextRPG_Practice.Scene
{
    internal class StartVillageScene : Scene
    {
        public StartVillageScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();
            this.game.PrintPlayer();

            sb.AppendLine("이곳은 시작 마을입니다.");
            sb.AppendLine("-----------------------");
            sb.AppendLine("1. 수련장으로 이동");
            sb.AppendLine("2. 던전으로 이동");
            sb.AppendLine("3. 회복");
            sb.AppendLine("4. 게임 종료");

            sb.Append("\n입력 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            int index = this.game.GetInput();

            switch (index)
            {
                case 1:
                    Console.WriteLine("수련장으로 이동합니다.");
                    Thread.Sleep(1000);
                    game.MoveMap(new TrainingMapScene(this.game));
                    break;
                case 2:
                    Console.WriteLine("던전으로 이동합니다.");
                    Thread.Sleep(1000);
                    game.MoveMap(new DungeonScene(this.game));
                    break;
                case 3:
                    Console.WriteLine("HP, MP를 모두 회복합니다.");
                    Thread.Sleep(1000);
                    Data.player.FullRecovery();
                    break;
                case 4:
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