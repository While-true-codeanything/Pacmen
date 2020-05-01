using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер поля(целое число):");
            int X = int.Parse(Console.ReadLine());
            Field f = new Field(X);
            f.RandomPlace();
            f.Start();
            Console.ReadKey();
        }
    }
}
