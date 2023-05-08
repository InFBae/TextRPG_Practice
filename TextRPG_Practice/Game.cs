using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG_Practice.Player;
using TextRPG_Practice.Scene;

namespace TextRPG_Practice
{
    public class Game
    {
        private bool running = true;

        private Scene.Scene scene;

        public void Run()
        {
            // Init
            Init();
            // Loop
            while (running)
            {
                // Render
                Render();
                // Update
                Update();
            }
            // Release

        }

        private void Init()
        {
            Data.Init();
            scene = new Scene.MainMenuScene(this);
        }

        private void Render()
        {
            Console.Clear();
            scene.Render();
        }

        public void PrintPlayer()
        {
            StringBuilder sb = new StringBuilder();
            Player.Player player = Data.player;

            PrintImage(player.image);

            sb.AppendLine($"이름 : {player.name}");
            sb.AppendLine($"HP : {player.HP}/{player.maxHP}");
            sb.AppendLine($"MP : {player.MP}/{player.maxMP}");
            sb.AppendLine($"EXP : {player.EXP}/{player.maxEXP}");
            sb.AppendLine($"공격력 : {player.AP}");

            Console.WriteLine(sb.ToString());
        }
        private void PrintImage(string image)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < image.Length; i++)
            {
                sb.Append(image[i]);
            }
            Console.WriteLine(sb.ToString());
        }

        private void Update()
        {
            scene.Update();
        }

        internal void GameStart()
        {
            Console.Write("플레이어의 이름을 입력해주세요 : ");
            string input = Console.ReadLine();
            Data.player.name = input;
            scene = new Scene.StartVillageScene(this);
        }

        internal void GameOver(string v)
        {
            Console.WriteLine(v);
            Thread.Sleep(1000);
            running = false;
        }

        internal int GetInput()
        {
            string input = Console.ReadLine();

            int index;
            if (!int.TryParse(input, out index))
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return -1;
            }
            return index;
        }

        internal void MoveMap(Scene.Scene moveScene)
        {
            scene = moveScene;
        }

        internal void BattleStart()
        {
            BattleScene battleScene = new BattleScene(this, scene);    
            scene = battleScene;
            battleScene.StartBattle(Data.monsters[0]);
        }
    }
}
