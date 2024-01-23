using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Game
{
    internal class Program
    {

        public class Player
        {
            static int x = 3;
            static int y = 7;
        }

        static void Main(string[] args)
        {
            for(int i = 0; i < roomHeight; i++)
            {
                for (int j = 0; j < roomWidth; j++)
                {
                    if (i == 0 || i == roomHeight - 1)
                    {
                        Console.Write("#");
                    }
                    else if(j == 0 || j == roomWidth - 1)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
