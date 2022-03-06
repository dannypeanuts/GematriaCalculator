using System;
using System.Collections.Generic;
using System.Text;

namespace GematriaCalculator.Model
{
    public class Numeric
    {
        public Numeric(string name, int length, bool geometric, bool arithmetic, List<int> series)
        {
            Series = new List<int>();
            Name = name;
            Length = length;
            Geometric = geometric;
            Arithmetic = arithmetic;
            Series = series;
        }
        public string Name { get; set; }
        public int Length { get; set; }
        public bool Geometric { get; set; }
        public bool Arithmetic { get; set; }
        public List<int> Series { get; set; }
    }
}
