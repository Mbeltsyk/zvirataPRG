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
                Console.Write("Volba: ");

                string volba = Console.ReadLine();

                if (volba == "1") Pridat();
                else if (volba == "2") Vypis();
                else if (volba == "3")
                {
                    Console.WriteLine("Podle ceho chcete filtrovat:");
                    Console.WriteLine("1) Jmeno");
                    Console.WriteLine("2) Vek");
                    Console.WriteLine("3) Druh");
                    Console.Write(":");
                    string filterTypeInput = Console.ReadLine();
                    string filterType = "";
                    switch (filterType)
                    {
                        case "1":
                            filterType = "Name";
                            break;
                        case "2":
                            filterType = "Age";
                            break;
                        case "3":
                            filterType = "Kind";
                            break;
                        default:
                            filterType = "Undefined"
                            break;
                    }
                    Console.Write("Filtr:");

                    Vypis(true, filterType)
                }
                
                else if (volba == "4") Adopce();

                else if (volba == "0") return;
            }
        }

        private void Pridat()
        {
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Druh: ");
            string druh = Console.ReadLine();

            int vek;
            while (true)
            {
                Console.Write("Věk: ");
                if (int.TryParse(Console.ReadLine(), out vek) && vek >= 0)
                    break;
            }

            evidence.Pridat(jmeno, druh, vek);
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

                Console.WriteLine("\nID | Jméno | Druh | Věk | Adoptováno");
            foreach (Zvire z in zvirataList)
            {
                Console.WriteLine($"{z.Id} | {z.Jmeno} | {z.Druh} | {z.Vek} | {(z.Adoptovano ? "ANO" : "NE")}");
            }
            Console.ReadKey();
        }

        private void Adopce()
        {
            Console.Write("ID zvířete: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(
                    evidence.Adoptovat(id)
                    ? "Zvíře adoptováno."
                    : "Nelze provést."
                );
            }
            Console.ReadKey();
        }
    }
}
