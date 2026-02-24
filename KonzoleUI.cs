using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
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
            string jmeno;
            string druh;
            int vek;
            string pohlavi;
            string zdravotniStav;
            string poznamka;

            do
            {
                Console.Write("Jméno: ");
                jmeno = Console.ReadLine();
                
                if (jmeno == "")
                {
                    Console.WriteLine("Toto pole je povinné.");
                }
            }
            while (jmeno == "");


            do
            {
                Console.Write("Druh: ");
                druh = Console.ReadLine();

                if (druh == "")
                {
                    Console.WriteLine("Toto pole je povinné.");
                }
            }
            while (druh == "");

            do
            {
                Console.Write("Věk: ");
                vek = int.Parse(Console.ReadLine());

                if (vek < 0)
                {
                    Console.WriteLine("Věk nemůže být záporný");
                }
            }
            while (vek < 0);

            do
            {
                Console.Write("Pohlaví: ");
                pohlavi = Console.ReadLine();

                if (pohlavi == "")
                {
                    Console.WriteLine("Toto pole je povinné.");
                }
            }
            while (pohlavi == "");

            do
            {
                Console.Write("Zdravotní stav: ");
                zdravotniStav = Console.ReadLine();

                if (zdravotniStav == "")
                {
                    Console.WriteLine("Toto pole je povinné.");
                }
            }
            while (zdravotniStav == "");

            Console.Write("Poznámka: ");
            poznamka = Console.ReadLine();

            evidence.Pridat(jmeno, druh, vek, pohlavi, zdravotniStav, poznamka);
        }

        private void Vypis(bool filter = false, string filterType="", string filterValue="")
        {
            Console.WriteLine("\nID | Jméno | Druh | Věk | Adoptováno | Pohlaví | Zdravotní stav | Poznámka");

            List<Zvire> zvirataList;


            if (!filter)
            {
                zvirataList = evidence.Vsechna();
            }
            else
            {
                zvirataList = evidence.Filtrovat(filterType, filterValue);
            }
            foreach (Zvire z in zvirataList)
            {
                Console.WriteLine($"{z.Id} | {z.Jmeno} | {z.Druh} | {z.Vek} | {(z.Adoptovano ? "ANO" : "NE")} | {z.Pohlavi} | {z.ZdravotniStav} | {z.Poznamka}");
            }
            
            Console.ReadKey();
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
