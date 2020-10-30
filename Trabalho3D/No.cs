using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho3D
{
    class No
    {
        private int pos;
        private No prox;
        private int count;

        public No(int pos,No prox)
        {
            this.pos = pos;
            this.prox = prox;
        }

        public void setProx(No no)
        {
            this.prox = no;
        }

        public No getProx()
        {
            return prox;
        }

        public void setPos(int pos)
        {
            this.pos = pos;
        }

        public int getPos()
        {
            return pos;
        }

        public void setCount(int count)
        {
            this.count = count;
        }

        public int getCount()
        {
            return count;
        }
    }
}
