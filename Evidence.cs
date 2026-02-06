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

        public List<Zvire> Filtrovat(string typFiltru, string filtr)
        {
            //name age kind
            List<Zvire> zvirataFiltrovana = new List<Zvire>();
            {
                foreach(Zvire zvire in zvirata)
                {
                    switch (typFiltru)
                    {
                        case "name":
                            if (zvire.Jmeno == filtr)
                            {
                                zvirataFiltrovana.Add(zvire);
                            }
                            break;

                        case "age":
                            if (zvire.Vek.ToString() == filtr)
                            {
                                zvirataFiltrovana.Add(zvire);
                            }
                            break;

                        case "kind":
                            if (zvire.Druh == filtr)
                            {
                                zvirataFiltrovana.Add(zvire);
                            }
                            break;
                    }
                }
                return zvirataFiltrovana;
            }
        }
    }
}
