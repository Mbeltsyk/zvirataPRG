using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yvirata
{
    class Evidence
    {
        private List<Zvire> zvirata = new List<Zvire>();
        private int nextId = 1;

        public Evidence()
        {
            Pridat("Rex", "Pes", 3);
            Pridat("Micka", "Kočka", 2);
        }

        public void Pridat(string jmeno, string druh, int vek)
        {
            zvirata.Add(new Zvire
            {
                Id = nextId++,
                Jmeno = jmeno,
                Druh = druh,
                Vek = vek,
                Adoptovano = false
            });
        }

        public List<Zvire> Vsechna()
        {
            return zvirata;
        }

        public bool Adoptovat(int id)
        {
            foreach (Zvire z in zvirata)
            {
                if (z.Id == id && !z.Adoptovano)
                {
                    z.Adoptovano = true;
                    return true;
                }
            }
            return false;
        }
    }
}
