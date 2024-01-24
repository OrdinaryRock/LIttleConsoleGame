using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    internal class Program
    {
        static int mapWidth = 32;
        static int mapHeight = 12;
        static string[][] map = new string[mapHeight][];
        public class Player
        {
            private static int x = 3;
            private static int y = 7;

            public static int GetX() { return x; }
            public static int GetY() { return y; }
            public static void SetX(int value) { x = value; }
            public static void SetY(int value) { y = value; }

            public static bool TryMovement(int xDistance, int yDistance)
            {
                int xTo = x + xDistance;
                int yTo = y + yDistance;
                if(Program.map[yTo][xTo] != "#")
                {
                    x += xDistance;
                    y += yDistance;
                }
                return true;
            }
        }

        static void Main(string[] args)
        {
            InitMap();
            DoTurn();
        }
        static void InitMap()
        {
            for (int i = 0; i < mapHeight; i++)
            {
                map[i] = new string[mapWidth];
            }
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    if (i == 0 || i == mapHeight - 1) map[i][j] = "#";
                    else if (j == 0 || j == mapWidth - 1) map[i][j] = "#";
                    else map[i][j] = " ";
                }
            }
        }
        static void DrawMap()
        {
            Console.Clear();
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    string tile = map[i][j];
                    if (Player.GetX() == j && Player.GetY() == i) Console.Write("@");
                    else Console.Write(tile);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Please enter your desired action!");
            Console.WriteLine("Up - Move one space up");
            Console.WriteLine("Down - Move one space down");
            Console.WriteLine("Left - Move one space left");
            Console.WriteLine("Right - Move one space right");
            Console.Write("\n>");
        }

        static void DoTurn()
        {
            DrawMap();
            string input = Console.ReadLine().ToLower();
            switch(input)
            {
                case "quit":
                    QuitGame();
                    return;
                    break;
                case "up":
                    Player.TryMovement(0, -1);
                    break;
                case "down":
                    Player.TryMovement(0, 1);
                    break;
                case "left":
                    Player.TryMovement(-1, 0);
                    break;
                case "right":
                    Player.TryMovement(1, 0);
                    break;
            }
            DoTurn();
        }

        static void QuitGame()
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing!");
        }
    }
}
