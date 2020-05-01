using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class Ghost : Entity
    {
        static Random r = new Random();
        public Ghost(int x, int y,Field f2) : base(x , y ) { f = f2;}
        private Boolean isAlive;
        private Field f;
        public override int move(ref int[,] field)
        {
            ArrayList variants = new ArrayList();
            if (y != 0)
            {
                if (field[y-1, x] == 0 || field[y-1, x] == 5)
                {
                    if (field[y-1, x] == 0) { int[] cord = new int[] { y - 1 , x }; variants.Add(cord); }
                    if (field[y-1, x] == 5) {field[y , x ] = 0;  if (f.AskPac) { isAlive = false; y = y - 1; return 6; }
                        else return -1;
                    }
                }
            }
            if (y != field.GetLength(0) - 1)
            {
                if (field[y + 1, x] == 0 || field[y + 1, x] == 5)
                {
                    if (field[y + 1, x] == 0) { int[] cord = new int[] { y + 1, x }; variants.Add(cord); }
                    if (field[y + 1, x] == 5) {field[y , x ] = 0;  if (f.AskPac) { isAlive = false;  y = y + 1; return 6; }
                        else return -1;
                    }
                }
            }
            if (x != 0)
            {
                if (field[y , x -1] == 0 || field[y , x -1] == 5)
                {
                    if (field[y , x -1] == 0) { int[] cord = new int[] { y , x -1 }; variants.Add(cord); }
                    if (field[y , x -1] == 5) { field[y , x ] = 0; if (f.AskPac) { isAlive = false;  x = x - 1; return 6; }
                        else return -1;
                    }
                }
            }
            if (x != field.GetLength(1) - 1)
            {
                if (field[y , x + 1] == 0 || field[y , x + 1] == 5)
                {
                    if (field[y , x + 1] == 0) { int[] cord = new int[] { y , x + 1 }; variants.Add(cord); }
                    if (field[y , x + 1] == 5)
                    {
                        field[y , x ] = 0;
                        if (f.AskPac) { isAlive = false;  x = x + 1; return 6; }
                        else return -1;
                    }
                }
            }
            int var = r.Next(0, variants.Count - 1);
            int[] coords = (int[])variants[var];
            field[y,x] = 0;
            y = coords[0];
            x = coords[1];
            field[y,x] = 2;
            return 0;
        }
    }
}


