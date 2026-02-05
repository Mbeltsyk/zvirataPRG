using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yvirata
{
    class Zvire
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Druh { get; set; }
        public int Vek { get; set; }
        public bool Adoptovano { get; set; }

        public Zvire(int id, string jmeno, string druh, int vek, bool adoptovano)
        {
            Id = id;
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Adoptovano = adoptovano;
        }
    }

}
