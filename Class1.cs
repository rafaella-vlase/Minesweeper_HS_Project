using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mine
{
    class Class1
    {
        private
            int[,] a;
        int n, m;
        int bomb;
        public Class1(int nn, int mm, int bb)
        {
            n = nn;
            m = mm;
            bomb = bb;
            a = new int[n + 2, m + 2];
            Random rnd = new Random();
            int i, j;
            for (i = 1; i <= n; i++)
                for (j = 1; j <= m; j++)
                    a[i, j] = 0;
            for (i = 1; i <= bb; )
            {
                int x = rnd.Next(0, n )+ 1;
                int y = rnd.Next(0, m )+ 1;
                if (x <= n && x >= 1 && y <= m && y >= 1 && a[x, y] == 0)
                {
                    a[x, y] = 1;
                    i++;
                }
            }
        }
        public int get(int i, int j)
        {
            return a[i, j];
        }
    }
}
