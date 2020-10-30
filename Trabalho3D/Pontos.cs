using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D
{
    class Pontos
    {
        private int x;
        private int y;
        private int z;
        private int r;
        private int g;
        private int b;

        public Pontos(String x, String y, String z)
        {
            this.x = Convert.ToInt32(Math.Round(Convert.ToDouble(x)));
            this.y = Convert.ToInt32(Math.Round(Convert.ToDouble(y)));
            this.z = Convert.ToInt32(Math.Round(Convert.ToDouble(z)));
        }

        public Pontos(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void setX(String x)
        {
            this.x = Convert.ToInt32(Math.Round(Convert.ToDouble(x)));
        }

        public void setY(String y)
        {
            this.y = Convert.ToInt32(Math.Round(Convert.ToDouble(y)));
        }

        public void setZ(String z)
        {
            this.z = Convert.ToInt32(Math.Round(Convert.ToDouble(z)));
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setZ(int z)
        {
            this.z = z;
        }

        public void setX(double x)
        {
            this.x = Convert.ToInt32(Math.Round(x));
        }

        public void setY(double y)
        {
            this.y = Convert.ToInt32(Math.Round(y));
        }

        public void setZ(double z)
        {
            this.z = Convert.ToInt32(Math.Round(z));
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

        /*RGB*/
        public int getR()
        {
            return r;
        }

        public void setR(int r)
        {
            this.r = r;
        }

        public int getG()
        {
            return g;
        }

        public void setG(int g)
        {
            this.g = g;
        }

        public int getB()
        {
            return b;
        }

        public void setB(int b)
        {
            this.b = b;
        }

        public void addRGB(int r, int g, int b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }
    }
}
