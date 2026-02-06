using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yvirata
{
    class KonzoleUI
    {
        private Evidence evidence;

        public KonzoleUI(Evidence evidence)
        {
            this.evidence = evidence;
        }

        public void Spustit()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== ÚTULEK =====");
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat zvířata");
                Console.WriteLine("3) Filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("0) Konec");
                Console.Write("Volba:");

                string volba = Console.ReadLine();
                Console.WriteLine();

                if (volba == "1") {
                    Pridat();
                }
                
                else if (volba == "2")
                {
                    Vypis(); Console.ReadKey();
                }

                else if (volba == "3")
                {
                    Console.WriteLine("Podle čeho chcete filtrovat:");
                    Console.WriteLine("1) Jméno");
                    Console.WriteLine("2) Věk");
                    Console.WriteLine("3) Druh");
                    Console.Write("Volba:");
                    string filterTypeInput = Console.ReadLine();
                    string filterType = "";
                    switch (filterTypeInput)
                    {
                        case "1":
                            filterType = "name";
                            break;
                        case "2":
                            filterType = "age";
                            break;
                        case "3":
                            filterType = "kind";
                            break;
                        default:
                            filterType = "undefined";
                            break;
                    }
                    Console.Write("Filtr:");
                    string filter = Console.ReadLine();

                    Vypis(true, filterType, filter);
                    Console.ReadKey();
                }
                
                else if (volba == "4") Adopce();

                else if (volba == "0") return;
            }
        }

        private void Pridat()
        {
            Console.Write("Jméno:");
            string jmeno = Console.ReadLine();

            Console.Write("Druh:");
            string druh = Console.ReadLine();

            int vek;
            while (true)
            {
                Console.Write("Věk:");
                if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0)
                    break;
            }

            Console.Write("\nJste si o údajech jisti?\n(a/n):");
            string Jistost = Console.ReadLine();

            if(Jistost.ToLower() == "a")
            {
                evidence.Pridat(jmeno, druh, vek);
            }
        }

        private void Vypis(bool filter = false, string filterType="", string filterValue="")
        {

            List<Zvire> zvirataList;


            if (!filter)
            {
                zvirataList = evidence.Vsechna();
            }
            else
            {
                zvirataList = evidence.Filtrovat(filterType, filterValue);
            }

            Console.WriteLine("ID | Jméno | Druh | Věk | Adoptováno");
            foreach (Zvire z in zvirataList)
            {
                Console.WriteLine($"{z.Id} | {z.Jmeno} | {z.Druh} | {z.Vek} | {(z.Adoptovano ? "ANO" : "NE")}");
            }
        }

        private void Adopce()
        {
            Vypis();
            Console.Write("\nID zvířete:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(
                    evidence.Adoptovat(id)
                    ? "Zvíře adoptováno."
                    : "Nelze provést."
                );
            }
            else
            {
                Console.Write("Nelze provést.");
            }
            Console.ReadKey();
        }
    }
}
