using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShipShooting
{
    class Program
    {
        static void printGrid(int[][] S)
        {
            Console.WriteLine();
            for (int i = 0; i < S.Length; i++)
            {
                for (int j = 0; j < S[0].Length; j++)
                {
                    Console.Write(S[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool Shoot(int[][] S, int x, int y, ref int cnt)
        {
            if (x < 0 || y < 0 || x >= S.Length || y >= S[0].Length || S[x][y] == 0 || S[x][y] == -1)
                return false;

            S[x][y] = -1;
            cnt++;

            Shoot(S, x + 1, y, ref cnt);
            Shoot(S, x - 1, y, ref cnt);
            Shoot(S, x, y - 1, ref cnt);
            Shoot(S, x, y + 1, ref cnt);

            return true;
        }

        static void DestroyShips(int[][] S)
        {
            int xmax = S.Length;
            int ymax = S[0].Length;
            
            int cnt = 0;            
            Random r = new Random();

            while (cnt < 6)
            {
                int x = r.Next(0, xmax);
                int y = r.Next(0, ymax);

                if (S[x][y] == 1)
                {
                    Shoot(S, x, y, ref cnt);
                }
            }

        }

        static void Main(string[] args)
        {
            int[][] S = { new int[3], new int[3], new int[3] };
            S[0][0] = 1;
            S[0][1] = 1;
            S[0][2] = 1;
            S[1][2] = 1;
            S[2][0] = 1;
            S[2][1] = 1;
            printGrid(S);
            DestroyShips(S);
            printGrid(S);
            Console.ReadLine();
        }
    }
}
