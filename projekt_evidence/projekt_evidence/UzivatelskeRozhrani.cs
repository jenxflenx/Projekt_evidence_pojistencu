using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_evidence
{
    // Třída pro interakci s uživatelem
    public class UzivatelskeRozhrani
    {
        // Načte a vrátí pojištěnce na základě vstupů od uživatele
        public Pojistenec NactiPojistence()
        {
            const int maxPokusy = 3; // Maximální počet pokusů
            int pokusy;

            string jmeno;
            pokusy = 0;
            do
            {
                Console.WriteLine("\nZadejte jméno pojištěného (nebo zadejte 'menu' pro návrat):");
                jmeno = Console.ReadLine();

                // Pokud uživatel zadá "menu", vrátí se do hlavní nabídky
                if (jmeno.ToLower() == "menu") return null;

                // Validace: Jméno nesmí být prázdné, musí obsahovat alespoň jedno písmeno
                // Povolené jsou pomlčky a mezery, ale jméno nesmí obsahovat pouze tyto znaky
                if (string.IsNullOrWhiteSpace(jmeno) || !jmeno.Any(char.IsLetter))
                {
                    Console.WriteLine("\nJméno musí obsahovat alespoň jedno písmeno a nesmí být složeno pouze z pomlček nebo mezer. Zadejte prosím znovu.");
                    pokusy++;
                }

                // Pokud uživatel překročí počet pokusů, vrátí se zpět
                if (pokusy >= maxPokusy)
                {
                    Console.WriteLine("\nPřekročen maximální počet pokusů pro zadání jména.");
                    return null;
                }
            } while (string.IsNullOrWhiteSpace(jmeno) || !jmeno.Any(char.IsLetter)); // Cyklus pokračuje, dokud není zadáno platné jméno

            string prijmeni;
            pokusy = 0;
            do
            {
                Console.WriteLine("Zadejte příjmení (nebo 'menu' pro návrat):");
                prijmeni = Console.ReadLine();

                // Možnost návratu
                if (prijmeni.ToLower() == "menu") return null;

                // Validace: Příjmení nesmí být prázdné, musí obsahovat alespoň jedno písmeno
                // Povolené jsou pomlčky a mezery, ale příjmení nesmí obsahovat pouze tyto znaky
                if (string.IsNullOrWhiteSpace(prijmeni) || !prijmeni.Any(char.IsLetter))
                {
                    Console.WriteLine("\nPříjmení musí obsahovat alespoň jedno písmeno a nesmí být složeno pouze z pomlček nebo mezer. Zadejte prosím znovu.");
                    pokusy++;
                }

                // Pokud uživatel překročí počet pokusů, vrátí se zpět
                if (pokusy >= maxPokusy)
                {
                    Console.WriteLine("\nPřekročen maximální počet pokusů pro zadání příjmení.");
                    return null;
                }
            } while (string.IsNullOrWhiteSpace(prijmeni) || !prijmeni.Any(char.IsLetter)); // Cyklus pokračuje, dokud není zadáno platné příjmení

            string telefonniCislo;
            pokusy = 0;
            do
            {
                Console.WriteLine("Zadejte telefonní číslo (nebo zadejte 'menu' pro návrat):");
                telefonniCislo = Console.ReadLine();

                // Možnost návratu
                if (telefonniCislo.ToLower() == "menu") return null;

                // Validace: Telefonní číslo musí obsahovat pouze číslice a nesmí být prázdné
                if (string.IsNullOrWhiteSpace(telefonniCislo) || !telefonniCislo.All(char.IsDigit))
                {
                    Console.WriteLine("\nTelefonní číslo musí obsahovat pouze číslice a nesmí být prázdné.");
                    pokusy++;
                }

                // Pokud uživatel překročí počet pokusů, vrátí se zpět
                if (pokusy >= maxPokusy)
                {
                    Console.WriteLine("\nPřekročen maximální počet pokusů pro zadání telefonního čísla.");
                    return null;
                }
            } while (string.IsNullOrWhiteSpace(telefonniCislo) || !telefonniCislo.All(char.IsDigit)); // Cyklus pokračuje dokud není zadáno platné číslo

            int vek;
            pokusy = 0;
            bool validVek = false;
            do
            {
                Console.WriteLine("Zadejte věk (nebo zadejte 'menu' pro návrat):");
                string vstup = Console.ReadLine();

                // Kontrola, zda uživatel zadal 'menu' pro návrat
                if (vstup.ToLower() == "menu") return null;

                // Validace: Věk musí být platné číslo
                validVek = int.TryParse(vstup, out vek);

                // Kontrola, zda je věk v rozumném rozmezí (0-130 let)
                if (!validVek || vek < 0 || vek > 130)
                {
                    Console.WriteLine("Zadejte platný věk (číslo mezi 0 a 130).");
                    pokusy++;
                }

                // Pokud uživatel překročí počet pokusů, vrátí se zpět
                if (pokusy >= maxPokusy)
                {
                    Console.WriteLine("\nPřekročen maximální počet pokusů pro zadání věku.");
                    return null;
                }
            } while (!validVek || vek < 0 || vek > 130); // Cyklus pokračuje, dokud není zadán platný věk

            return new Pojistenec(jmeno, prijmeni, telefonniCislo, vek); // Vrací nového pojištěnce s validními údaji
        }

        // Načte a vrátí jméno a přijmení pro vyhledání
        public (string, string) NactiJmenoAPrijmeni()
        {
            Console.WriteLine("\n\nZadejte jméno pojištěného:");
            string jmeno = Console.ReadLine();

            Console.WriteLine("Zadejte příjmení:");
            string prijmeni = Console.ReadLine();

            return (jmeno, prijmeni); // Vrátí dvojici jméno a příjmení (Tuple)
        }

        // Metoda pro výpis všech pojištěnců na konzoli
        public void VypisPojistence(List<Pojistenec> pojistenci)
        {
            // Kontrola, zda seznam není prázdný
            if (pojistenci.Count == 0)
            {
                // Pokud není žádný pojištěnec evidován, vypíše zprávu
                Console.WriteLine("\nŽádní pojištěnci nejsou evidováni.");
            }
            else
            {
                Console.WriteLine("\nSeznam pojištěnců:");

                // Projde všechny pojištěnce v seznamu a vypíše každého zvlášť
                foreach (Pojistenec pojistenec in pojistenci)
                {
                    // Přidání oddělujících čar pro lepší čitelnost
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine(pojistenec.ToString()); // Volá metodu ToString z třídy Pojistenec
                    Console.WriteLine("\n-----------------------------------");
                }
            }
        }
    }
}
