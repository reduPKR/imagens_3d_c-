using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D.Scanline
{
    class ET
    {
        private Caixa inicio;
        private ET next;
        private int num;
        public ET()
        {
            inicio = null;
            next = null;
            num = -1;
        }

        public void setNum(int x)
        {
            num = x;
        }

        public ET(int y, ET p)
        {
            num = y;
            next = p;
            inicio = null;
        }

        public ET getNext()
        {
            return next;
        }

        public void setNext(ET et)
        {
            next = et;
        }

        public int getNum()
        {
            return num;
        }

        public void setInicio(Caixa c)
        {
            c.setProx(inicio);
            inicio = c;
        }

        public Caixa getInicio()
        {
            return inicio;
        }
    }
}
