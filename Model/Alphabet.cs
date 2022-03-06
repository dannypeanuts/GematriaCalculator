using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class Alphabet
    {
        public Alphabet(string name, List<char> chars)
        {
            Chars = new List<char>();
            Name = name;
            Length = chars.Count;
            Chars = chars;
        }
        public string Name { get; set; }
        public int Length { get; set; }
        public List<char> Chars { get; set; }
    }
}
