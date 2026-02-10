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
        public string Pohlavi { get; set; }
        public DateTime DatumPrijmu
        {
            get
            {
                return DateTime.Today;
            }
        }
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }

        public Zvire(int id, string jmeno, string druh, int vek, bool adoptovano, string pohlavi, string zdravotniStav, string poznamka)
        {
            Id = id;
            Jmeno = jmeno;
            Druh = druh;
            Vek = vek;
            Adoptovano = adoptovano;
            Pohlavi = pohlavi;
            ZdravotniStav = zdravotniStav;
            Poznamka = poznamka;
        }
    }

}
