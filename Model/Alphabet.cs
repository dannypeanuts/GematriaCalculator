using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class Alphabet
    {
        public Alphabet(string name, int length, string cases, List<char> chars)
        {
            Chars = new List<char>();
            Name = name;
            Length = length;
            Case = cases;
            Chars = chars;
        }
        public string Name { get; set; }
        public int Length { get; set; }
        public string Case { get; set; }
        public List<char> Chars { get; set; }
    }
}
