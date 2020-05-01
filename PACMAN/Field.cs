using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class Field
    {
        private int[,] field;
        private static Random r = new Random();
        private Ghost[] g=new Ghost[2];
        private SmartGhost[] sg = new SmartGhost[2];
        private Pacman pac;
        public Field(int N)
        {
            field = new int[N,N];
        }
        public Boolean AskPac
        {
            get
            {
                return pac.ChBuff;
            }
        }
        public void RandomPlace() {
            for (int i = 0; i < field.GetLength(0) * field.GetLength(0) / 3; i++)
            {
                int x = r.Next(0, field.GetLength(0) - 1);
                int y = r.Next(0, field.GetLength(0) - 1);
                if (field[y, x] != 1) field[y, x] = 1;
                else { i--; }
            }
            int x1;
            int y1;
            for (int i = 0; i < 2; i++) {
                do
                {
                    x1 = r.Next(0, field.GetLength(0) - 1);
                    y1 = r.Next(0, field.GetLength(0) - 1);
                } while (field[y1, x1] != 0);
                field[y1, x1] = 2;
                g[i] = new Ghost(x1, y1,this);
        }
            for (int i = 3; i < 5; i++)
            {
                do
                {
                    x1 = r.Next(0, field.GetLength(0) - 1);
                    y1 = r.Next(0, field.GetLength(0) - 1);
                } while (field[y1, x1] != 0);
                field[y1, x1] = i;
                sg[i-3] = new SmartGhost(x1, y1,i, this);
            }
            do
            {
                x1 = r.Next(0, field.GetLength(0) - 1);
                y1 = r.Next(0, field.GetLength(0) - 1);
            } while (field[y1, x1] != 0);
            field[y1, x1] = 5;
            pac = new Pacman(x1, y1);
            for (int i = 0; i < 4; i++)
            {
                do
                {
                    x1 = r.Next(0, field.GetLength(0) - 1);
                    y1 = r.Next(0, field.GetLength(0) - 1);
                } while (field[y1, x1] != 0);
                field[y1, x1] = 6;
            }
        }
        public void Vivod()
        {
            for(int i = 0; i < field.GetLength(0); i++)
            {
                for (int o = 0; o < field.GetLength(1); o++)
                {
                    switch (field[i, o])
                    {
                        case 0:
                            {
                                Console.Write(" ");
                                break;
                            }
                        case 1:
                            {
                                Console.Write("W");
                                break;
                            }
                        case 2:
                            {
                                Console.Write("G");
                                break;
                            }
                        case 3:
                        case 4:
                            {
                                Console.Write("S");
                                break;
                            }
                        case 5:
                            {
                                Console.Write("P");
                                break;
                            }
                        case 6:
                            {
                                Console.Write("C");
                                break;
                            }
                    }
                }
                Console.WriteLine();
            }
        }
        public void Start()
        {
            while (true)
            {
                Vivod();
                int id=pac.move(ref field);
                if (CheckReconId(id) == false) break;
                if (g[0].Alive)
                {
                    id = g[0].move(ref field);
                    if (CheckReconId(id) == false) break;
                }
                if (g[1].Alive)
                {
                    id = g[1].move(ref field);
                    if (CheckReconId(id) == false) break;
                }
                if (sg[0].Alive)
                {
                    id = sg[0].move(ref field);
                    if (CheckReconId(id) == false) break;
                }
                if (sg[1].Alive)
                {
                    id = sg[1].move(ref field);
                    if (CheckReconId(id) == false) break;
                }
            }
        }
        private Boolean CheckReconId(int x)
        {
            switch (x)
            {
                case -1:
                    {
                        Console.WriteLine("Вас сьели! Вы проиграли!");
                        return false;
                    }
                case 0:
                    {
                        return true;
                    }
                case 4:
                    {
                        Console.WriteLine("Вы сьели вишенку, вы на время усилены!");
                        return true;
                    }
                case 6:
                    {
                        if (!g[0].Alive)
                        {
                            if (!g[1].Alive)
                            {
                                if (!sg[0].Alive)
                                {
                                    if (!sg[1].Alive)
                                    {
                                        Console.WriteLine("Вы победили!");
                                        return false;
                                    }
                                }
                            }
                        }
                        if (Entity.Equals(pac, g[0])) g[0].Alive = false;
                            if (Entity.Equals(pac, g[1])) g[1].Alive = false;
                            if (Entity.Equals(pac, sg[0])) g[0].Alive = false;
                            if (Entity.Equals(pac, sg[1])) g[1].Alive = false;
                        Console.WriteLine("Вы сьели приведение!");
                        return true;
                    }
            }
            Console.WriteLine("Что-то сломалось в коде!");
            return false;
        }
    }


}
