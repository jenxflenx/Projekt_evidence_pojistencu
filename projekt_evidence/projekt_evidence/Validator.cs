using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt_evidence
{
    public class Validator
    {
        public static bool ValidujJmeno(string jmeno)
        {
            return !string.IsNullOrWhiteSpace(jmeno) && jmeno.Any(char.IsLetter);
        }

        public static bool ValidujTelefonniCislo(string telefonniCislo)
        {
            return !string.IsNullOrWhiteSpace(telefonniCislo) && telefonniCislo.All(char.IsDigit);
        }

        public static bool ValidujVek(int vek)
        {
            return vek >= 0 && vek <= 130;
        }
    }
}
