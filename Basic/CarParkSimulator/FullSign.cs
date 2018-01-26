using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarParkSimulator
{
    class FullSign
    {
        private bool lit;

        public FullSign()
        {
            lit = false;
        }

        public bool isLit()
        {
            return lit;
        }

        public void SetLit(bool toggle)
        {
            lit = toggle;
        }
    }
}
