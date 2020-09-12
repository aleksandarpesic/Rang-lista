using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //mora da se ukljuci zbog nasledjivanja Button

namespace Rang_lista
{
    public class myButton : Button
    {
        private int num1;

        public int Num1
        {
            get { return num1; }
            set { num1 = value; }
        }
    }
}
