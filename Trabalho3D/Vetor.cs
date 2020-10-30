using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D
{
    class Vetor
    {
        private int x;
        private int y;
        private int z;

        public Vetor(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vetor(Pontos ab, Pontos ac)
        {
            this.x = (ab.getY() * ac.getZ()) - (ac.getY() * ab.getZ());
            this.y = (ab.getZ() * ac.getX()) - (ac.getZ() * ab.getX());
            this.z = (ab.getX() * ac.getY()) - (ab.getY() * ac.getX());
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public int getZ()
        {
            return z;
        }

        public void setX()
        {
            this.x = x;
        }

        public void setY()
        {
            this.y = y;
        }

        public void setZ()
        {
            this.z = z;
        }
    }
}
