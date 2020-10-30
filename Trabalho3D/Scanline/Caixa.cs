using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D.Scanline
{
    class Caixa
    {
        private double Ymax, Xmin;
        private double Incx;
        private Caixa prox, ant;

        public Caixa(double y, double x, double inc)
        {
            Ymax = y;
            Xmin = x;
            Incx = inc;
            prox = null;
            ant = null;
        }

        public void setAnt(Caixa c)
        {
            ant = c;
        }

        public Caixa getAnt()
        {
            return ant;
        }

        public void setProx(Caixa c)
        {
            prox = c;
        }

        public Caixa getProx()
        {
            return prox;
        }

        public double getYmax()
        {
            return Ymax;
        }

        public void setYmax(double y)
        {
            Ymax = y;
        }

        public double getXmin()
        {
            return Xmin;
        }

        public void setXmin(double x)
        {
            Xmin = x;
        }
        public double getIncx()
        {
            return Incx;
        }
        public void setIncx(double inc)
        {
            Incx = inc;
        }
    }
}
