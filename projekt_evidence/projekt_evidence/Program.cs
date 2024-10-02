using System.Runtime.CompilerServices;

namespace projekt_evidence
{
    // Hlavní program aplikace
    internal class Program
    {
        // Hlavní metoda aplikace
        static void Main(string[] args)
        {
            Evidence evidence = new Evidence(); // Vytvoření instance třídy Evidence pro správu pojištěnců
            UzivatelskeRozhrani uzivatelskeRozhrani = new UzivatelskeRozhrani(); // Vytvoření instance pro uživatelské rozhraní

            Console.WriteLine("--------------------------");
            Console.WriteLine("Evidence pojištěných");
            Console.WriteLine("--------------------------");

            // Hlavní smyčka programu
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Vyberte si akci:");
                Console.WriteLine("1 - Přidat nového pojištěného");
                Console.WriteLine("2 - Vypsat všechny pojištěné");
                Console.WriteLine("3 - Vyhledat pojištěného");
                Console.WriteLine("4 - Konec");
                char volba = Console.ReadKey(true).KeyChar; // Čte volbu uživatele bez zobrazení klávesy v konzoli

                // Zpracování volby uživatele
                switch (volba)
                {
                    case '1': // Přidání nového pojištěnce
                        Pojistenec novyPojistenec = uzivatelskeRozhrani.NactiPojistence();
                        if (novyPojistenec == null) // Pokud uživatel zadal "menu" nebo překročil pokusy
                        {
                            Console.WriteLine("\nNávrat do hlavní nabídky...");
                            break; // Vrátíme se do hlavní nabídky bez přidání pojištěnce
                        }
                        evidence.PridatPojistence(novyPojistenec); // Přidá platného pojištěnce
                        Console.WriteLine("\nPojištěnec byl úspěšně přidán.");
                        break;
                    case '2': // Výpis všech pojištěnců
                        uzivatelskeRozhrani.VypisPojistence(evidence.VratVsechnyPojistence());
                        break;
                    case '3': // Vyhledání pojištěnce podle jména a přijmení
                        var (jmeno, prijmeni) = uzivatelskeRozhrani.NactiJmenoAPrijmeni(); // Dvojice jméno a příjmení se "rozbalí" do jednotlivých proměnných díky metodě NactiJmenoAPrijmeni
                        Pojistenec hledanyPojistenec = evidence.NajdiPojistence(jmeno, prijmeni);

                        if (hledanyPojistenec != null) // Pokud je null, vypíše se, že hledaný pojištěnec nebyl nalezen
                        {
                            Console.WriteLine(hledanyPojistenec.ToString());
                        }
                        else
                        {
                            Console.WriteLine("\nPojištěnec nebyl nalezen.");
                        }
                        break;
                    case '4':
                        return; // Ukončení aplikace
                    default: // Neplatná volba
                        Console.WriteLine("\nNeplatná volba. Zkuste to znovu");
                        break;
                }
            }
        }
    }
}
