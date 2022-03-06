using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class Language
    {
        public Language(string name, string alphabet, string numeric, string cases="Upper")
        {
            Name = name;
            Alphabet = alphabet;
            Numeric = numeric;
            Case = cases;
        }
        public string Name { get; set; }
        public string Alphabet { get; set; }
        public string Numeric { get; set; }
        public string Case { get; set; }
    }
}
