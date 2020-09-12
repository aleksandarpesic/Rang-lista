using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rang_lista
{
    public class Igrac
    {
        private String ime;
        public int poeni;
        public bool ukljucen;

        public Igrac(String s)
        {
            ime = s;
            poeni = 0;
            ukljucen = false;
        }
        public Igrac(Igrac k)
        {
            this.poeni = k.getPoeni();
            this.ime = k.getIme();
            this.ukljucen = k.ukljucen;
        }
        public Igrac() { }
        public void Poeni_inc() { ++poeni; }

        public void Igra_Pauzira(bool b)
        {
            ukljucen = b;
        }
        public void SetIme(String s)
        {
            ime = s;
        }
        public String getIme()
        {
            return ime;
        }
        public int getPoeni()
        {
            return poeni;
        }
    }
}
