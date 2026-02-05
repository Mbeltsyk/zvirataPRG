Útulek pro zvířata

 Funkce aplikace
 přidání zvířete (jméno, druh, věk v letech, pohlaví, datum příjmu, zdravotní stav, poznámka)
 automatické přidělení ID
výpis všech zvířat v přehledné tabulce
 označení zvířete jako adoptovaného
 základní validace vstupů (věk musí být číslo ≥ 0)



Struktura projektu
Program– hlavní spouštěcí třída aplikace
Zvire – datový model zvířete (ID, jméno, druh, věk, adoptováno)
Evidence – práce se seznamem zvířat (přidání, výpis, adopce)
KonzoleUI – komunikace s uživatelem přes konzoli



 Rozdělení rolí v týmu
Maksym – třída Zvire (model dat)
Honza – třída Evidence (logika aplikace)
Simon – třída KonzoleUI a Program.cs



 Jak aplikaci spustit
1. Otevřít projekt ve Visual Studio nebo Visual Studio Code
2. Zkontrolovat, že je nainstalováno .NET SDK
3. Spustit projekt:
    ve Visual Studio klávesou F5
