using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class GemSystem
    {
        public GemSystem(char chr, int val)
        {
            Char = chr;
            Value = val;
        }
        public char Char { get; set; }
        public int Value { get; set; }
    }
}
