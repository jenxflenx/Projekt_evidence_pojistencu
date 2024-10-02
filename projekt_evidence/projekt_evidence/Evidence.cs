using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_evidence
{
    // Třída pro správu seznamu pojištěnců
    public class Evidence
    {
        // Uchovává seznam pojištěnců
        private List<Pojistenec> pojistenci = new List<Pojistenec>();

        // Přidání nového pojištěnce do seznamu
        public void PridatPojistence(Pojistenec pojistenec)
        {
            pojistenci.Add(pojistenec);
        }

        // Vrací seznam všech pojištěnců
        public List<Pojistenec> VratVsechnyPojistence()
        {
            return pojistenci;
        }

        // Vyhledání pojištěnce podle jména a příjmení
        public Pojistenec NajdiPojistence(string jmeno, string prijmeni)
        {
            // Vyhledá pojištěnce, který odpovídá zadanému jménu a příjmení (case-insensitive - nezáleží na velikosti písmen)
            return pojistenci.FirstOrDefault(p => p.Jmeno.Equals(jmeno, StringComparison.OrdinalIgnoreCase)
                                                  && p.Prijmeni.Equals(prijmeni, StringComparison.OrdinalIgnoreCase));
        }
    }
}
