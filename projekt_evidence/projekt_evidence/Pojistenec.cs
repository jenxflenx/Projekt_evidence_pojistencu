using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_evidence
{
    // Třída reprezentující pojištěnce
    public class Pojistenec
    {
        // Vlastnosti pojištěnce - jméno, příjmení, telefonní číslo a věk
        public string Jmeno { get; private set; }
        public string Prijmeni { get; private set; }
        public string TelefonniCislo { get; private set; }
        public int Vek { get; private set; }

        // Konstruktor pro vytvoření nového pojištěnce
        public Pojistenec(string jmeno, string prijmeni, string telefonniCislo, int vek)
        {
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            TelefonniCislo = telefonniCislo;
            Vek = vek;
        }

        // Vrací textovou reprezentaci pojištěnce
        public override string ToString()
        {
            return $"\n{Jmeno} {Prijmeni}, {Vek} let, Tel: {TelefonniCislo}";
        }
    }
}
