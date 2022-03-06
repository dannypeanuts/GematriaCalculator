using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class Gematria
    {
        public Gematria()
        {
            Pairs = new Dictionary<char, int>();
        }
        public string Name { get; set; }
        public bool Geometric { get; set; }
        public bool Arithmetic { get; set; }
        public Dictionary<char, int> Pairs { get; set; }
    }
}
