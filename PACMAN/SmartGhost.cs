using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class SmartGhost : Entity
    {
        public SmartGhost(int x, int y,int i, Field f2) : base(x, y) { id = i;f = f2;}
        protected int id;
        private Field f;
        private Boolean alive;
        private int findmex(out int y, int[,] field)
        {
            y = -1;
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int o = 0; o < field.GetLength(1); o++)
                {
                    if (field[i, o] == id){ y = i; return o; }
                }
            }
            return 0;
        }
        protected int move2(int[,] field, int prevx, int prevy)
        {
            int ycur = 0;
            int xcur = findmex( out ycur, field);
            int dir = 0;
            if (ycur != 0)
            {
                if ((field[ycur - 1, xcur] == 0 || field[ycur - 1, xcur] == 5)&&(ycur-1!=prevy))
                {
                    if (field[ycur - 1, xcur] == 0)
                    {
                        int[,] fieldcop = new int[field.GetLength(0), field.GetLength(1)];
                        Array.Copy(field, fieldcop, field.Length);
                        fieldcop[ycur - 1, xcur] = id;
                        dir = move2(fieldcop, xcur , ycur);
                    }
                        if (field[ycur - 1, xcur] == 5)  return 1;
                }
            }
            if (dir != 0) return dir;
            if (ycur != field.GetLength(0) - 1)
            {
                if ((field[ycur + 1, xcur] == 0 || field[ycur + 1, xcur] == 5)&& (ycur + 1 != prevy))
                {
                    if (field[ycur + 1, xcur] == 0)
                    {
                        int[,] fieldcop = new int[field.GetLength(0), field.GetLength(1)];
                        Array.Copy(field, fieldcop, field.Length);
                        fieldcop[ycur + 1, xcur] = id;
                        dir = move2(fieldcop, xcur, ycur);
                    }
                    if (field[ycur + 1, xcur] == 5) ycur = ycur + 1; return 2;
                }
            }
            if (dir != 0) return dir;
            if (xcur != 0)
            {
                if ((field[ycur , xcur-1] == 0 || field[ycur , xcur-1] == 5) && (xcur - 1 != prevx))
                {
                    if (field[ycur , xcur-1] == 0)
                    {
                        int[,] fieldcop = new int[field.GetLength(0), field.GetLength(1)];
                        Array.Copy(field, fieldcop, field.Length);
                        fieldcop[ycur, xcur-1] = id;
                        dir = move2(fieldcop, xcur, ycur);
                    }
                    if (field[ycur , xcur-1] == 5) xcur = xcur - 1; return 3;
                }
            }
            if (dir != 0) return dir;
            if (xcur != field.GetLength(1) - 1)
            {
                if ((field[ycur , xcur + 1] == 0 || field[ycur , xcur + 1] == 5)&&(xcur + 1 != prevx))
                {
                    if (field[ycur , xcur + 1] == 0)
                    {
                        int[,] fieldcop = new int[field.GetLength(0), field.GetLength(1)];
                        Array.Copy(field, fieldcop, field.Length);
                        fieldcop[ycur, xcur + 1] = id;
                        dir = move2(fieldcop, xcur, ycur);
                    }
                    if (field[ycur , xcur + 1] == 5) xcur = xcur - 1; return 4;
                }
            }
            return dir;
        }
        public override int move(ref int[,] field)
        {
            int res = this.move2(field, -1, -1);
            switch (res)
            {
                case 0:
                    {
                        Console.WriteLine("Путь не найден или пакммен под вишенкой, лучше подожду");
                        break;
                    }
                case 1:
                    {
                        if (field[y - 1, x] == 5 && f.AskPac == false) { y = y - 1; return -1; }
                        else { if (field[y - 1, x] != 5) field[y, x] = 0; y = y - 1; field[y, x] = id; }
                        break;
                    }
                case 2:
                    {
                        if (field[y+1, x] == 5 && f.AskPac == false) { y = y + 1; return -1; }
                        else { if (field[y+1, x] != 5) field[y, x] = 0; y = y + 1; field[y, x] = id; }
                        break;
                    }
                case 3:
                    {
                        if (field[y, x-1] == 5&&f.AskPac==false) { x = x - 1; return -1; }
                        else { if (field[y, x-1] != 5) field[y, x] = 0; x = x - 1; field[y, x] = id; }
                        break;
                    }
                case 4:
                    {
                        if (field[y, x+1] == 5 && f.AskPac == false) { x = x + 1; return -1; }
                        else { if (field[y, x+1] != 5) field[y, x] = 0; x = x + 1; field[y, x] = id; }
                        break;
                    }
            }
            return 0;
        }
    }
}
