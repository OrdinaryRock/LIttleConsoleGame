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
            public static int x = 3;
            public static int y = 7;
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
                    if (Player.x == j && Player.y == i) Console.Write("@");
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
                    Player.y--;
                    break;
                case "down":
                    Player.y++;
                    break;
                case "left":
                    Player.x--;
                    break;
                case "right":
                    Player.x++;
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
