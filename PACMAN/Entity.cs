using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACMAN
{
    class Entity
    {
        protected int x;
        protected int y;
        protected Boolean isAlive;
        public Boolean Alive
        {
            get
            {
                if (isAlive) return true;
                else return false;
            }
            set
            {
                isAlive = value;
            }
        }
        static public Boolean SameCoord(Entity o1, Entity o2)
        {
            if (o1.x == o2.x && o1.y == o2.y) return true;
            else return false;
        }
        public Entity(int x,int y)
        {
            this.x = x;
            this.y = y;
            isAlive = true;
        }
        public virtual int move(ref int[,] field) { return 0; }
    }
}
