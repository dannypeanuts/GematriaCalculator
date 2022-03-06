using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class GemMethod
    {
        public GemMethod(string chr, int val)
        {
            Char = chr;
            Value = val;
        }
        public string Char { get; set; }
        public int Value { get; set; }
    }
}
