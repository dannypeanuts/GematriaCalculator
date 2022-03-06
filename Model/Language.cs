using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class Language
    {
        public Language(string name, string alphabet, int length, string cases="Upper")
        {
            Name = name;
            Alphabet = alphabet;
            Length = length;
            Case = cases;
        }
        public string Name { get; set; }
        public string Alphabet { get; set; }
        public int Length { get; set; }
        public string Case { get; set; }
    }
}
