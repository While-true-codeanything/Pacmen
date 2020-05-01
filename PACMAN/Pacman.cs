using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class Pacman: Entity
    {
        public Pacman(int x, int y) : base(x, y) { }
        private int isBuffed;
        public Boolean ChBuff
        {
            get
            {
                if (isBuffed > 0) return true;
                else return false;
            }
        }
        public override int move(ref int[,] field)
        {
            String dir;
            do
            {
                Console.WriteLine("Введите направление(WASD): ");
                dir = Console.ReadLine();
            } while (dir != "W" && dir != "A" && dir != "S" && dir != "D");

            switch (dir)
            {
                case "W":
                    {
                        if (y != 0)
                        {
                            if (field[y - 1,x] == 0 || field[y - 1,x] == 6||(isBuffed>0&&(field[y - 1,x] ==3|| field[y - 1,x]==2 || field[y - 1,x] == 4)))
                            {
                                if (field[y - 1,x] == 0){ field[y, x] = 0; y = y - 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; } return 0; }
                                if (field[y - 1,x] == 6) { field[y, x] = 0; y = y - 1; field[y, x] = 5; isBuffed += 5; return 4; }
                                if (isBuffed > 0 && (field[y - 1,x] == 3 || field[y - 1,x] == 2 || field[y - 1,x] == 4)){ field[y, x] = 0; y = y - 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; } return 6;}
                            }
                        }
                        break;
                    }
                case "S":
                    {
                        if (y != field.GetLength(0) - 1)
                        {
                            if (field[y + 1,x] == 0 || field[y + 1,x] == 6 || (isBuffed > 0 && (field[y + 1,x] == 3 || field[y + 1,x] == 2 || field[y + 1,x] == 4)))
                            {
                                if (field[y + 1,x] == 0){ field[y, x] = 0; y = y + 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; } return 0; }
                                if (field[y + 1,x] == 6) { field[y, x] = 0; y = y + 1; field[y, x] = 5; isBuffed += 5; return 4; }
                                if (isBuffed > 0 && (field[y + 1,x] == 3 || field[y + 1,x] == 2 || field[y + 1,x] == 4)) { field[y, x] = 0; y = y + 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; } return 6;}
                            }
                        }
                        break;
                    }
                case "A":
                    {
                        if (x != 0)
                        {
                            if (field[y ,x-1] == 0 || field[y ,x-1] == 6 || (isBuffed > 0 && (field[y ,x-1] == 3 || field[y ,x-1] == 2 || field[y ,x-1] == 4)))
                            {
                                if (field[y ,x-1] == 0){ field[y, x] = 0; x = x - 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; } return 0; }
                                if (field[y ,x-1] == 6) { field[y, x] = 0; x = x - 1; field[y, x] = 5; isBuffed += 5; return 4; }
                                if (isBuffed > 0 && (field[y ,x-1] == 3 || field[y ,x-1] == 2 || field[y ,x-1] == 4)){ field[y, x] = 0; x = x - 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; }return 6;}
                            }
                        }
                        break;
                    }
                case "D":
                    {
                        if (x != field.GetLength(1) - 1)
                        {
                            if (field[y ,x+1] == 0 || field[y ,x+1] == 6 || (isBuffed > 0 && (field[y ,x+1] == 3 || field[y ,x+1] == 2 || field[y ,x+1] == 4)))
                            {
                                if (field[y ,x+1] == 0) { field[y, x] = 0; x = x + 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; } return 0; }
                                if (field[y ,x+1] == 6) { field[y, x] = 0; x = x + 1; field[y, x] = 5; isBuffed += 5; return 4; }
                                if (isBuffed > 0 && (field[y ,x+1] == 3 || field[y ,x+1] == 2 || field[y ,x+1] == 4)){ field[y, x] = 0; x = x + 1; field[y, x] = 5; if (isBuffed > 0) { isBuffed--; }return 6;}
                            }
                        }
                        break;
                    }
            }
            return 0;
        }
    }
}
