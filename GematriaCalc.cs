using CsvHelper;
using GematriaCalculator.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GematriaCalculator
{
    public class GematriaCalc
    {
        private const int antiChrist = 666;
        public List<Language> Languages = new List<Language>();
        public List<Alphabet> Alphabets = new List<Alphabet>();
        public List<Numeric> Numerics = new List<Numeric>();
        public List<Gematria> Gematrias = new List<Gematria>();
        public List<GemResult> GemResults = new List<GemResult>();
        public List<GemSystem> GemSystems = new List<GemSystem>();
        public List<GemMethod> GemMethods = new List<GemMethod>();

        public GematriaCalc()
        {
            ReadLanguageFile();
            ReadAlphabetFile();
            ReadNumericFile();
        }

        private void ReadLanguageFile()
        {
            try
            {
                var mainPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var filePath = mainPath + "\\Data\\Language.csv";
                using (var reader = new StreamReader(filePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<dynamic>();
                        Languages = new List<Language>();
                        foreach (var record in records)
                        {
                            try
                            {
                                var name = record.Name;
                                var alphabet = record.Alphabet;
                                var numeric = record.Numeric;
                                var cases = record.Case;
                                var language = new Language(name, alphabet, numeric, cases);
                                Languages.Add(language);
                            }
                            catch { }                           
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR ReadLanguageFile: " + err);
            }
        }

        private void ReadAlphabetFile()
        {
            try
            {
                var mainPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var filePath = mainPath + "\\Data\\Alphabet.csv";
                using (var reader = new StreamReader(filePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<dynamic>();
                        Alphabets = new List<Alphabet>();
                        foreach (var record in records)
                        {
                            try
                            {
                                string name = record.Name;
                                string[] strings = record.Chars.Split(',');
                                var chars = new List<char>();
                                foreach (var str in strings)
                                {
                                    var chr = Convert.ToChar(str);
                                    chars.Add(chr);
                                }
                                var alphabet = new Alphabet(name, chars);
                                Alphabets.Add(alphabet);
                            }
                            catch { }                       
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR ReadAlphabetFile: " + err);
            }
        }

        private void ReadNumericFile()
        {
            try
            {
                var mainPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                var filePath = mainPath + "\\Data\\Numeric.csv";
                using (var reader = new StreamReader(filePath))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        var records = csv.GetRecords<dynamic>();
                        Numerics = new List<Numeric>();
                        foreach (var record in records)
                        {
                            try
                            {
                                string name = record.Name;
                                bool geometric = Convert.ToBoolean(record.Geometric);
                                bool arithmetic = Convert.ToBoolean(record.Arithmetic);
                                string[] strings = record.Series.Split(',');
                                var series = new List<int>();
                                foreach (var str in strings)
                                {
                                    var num = Convert.ToInt32(str);
                                    series.Add(num);
                                }
                                var numeric = new Numeric(name, geometric, arithmetic, series);
                                Numerics.Add(numeric);
                            }
                            catch { }                        
                        }
                    }
                }
                var maxNum = Numerics.Max(r => r.Length);
                var maxAlph = Alphabets.Max(r => r.Length);
                if (maxAlph>maxNum)
                    throw new Exception($"Numeric series length must be bigger than Alpha characters length!");
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR ReadNumericFile: " + err);
            }

        }

        private string CheckName(string men_name, string cases)
        {
            try
            {
                var NoSpace = String.Concat(men_name.Where(c => !Char.IsWhiteSpace(c)));
                var Letter = String.Concat(NoSpace.SkipWhile(c => !Char.IsLetter(c)));
                switch (cases)
                {
                    case "Upper": men_name = Letter.ToUpper(); break;
                    case "Lower": men_name = Letter.ToLower(); break;
                }
                
            }
            catch(Exception err)
            {
                Console.WriteLine("ERROR CheckName: " + err);
            }
            return men_name;
        }

        public void GenerateGematria(string language="English", bool canreverse=false)
        {
            Gematrias = new List<Gematria>();
            try
            {
                var languages = Languages.Where(r => r.Name == language);
                var alphabets = Alphabets.Where(a => languages.Any(l => a.Name == l.Alphabet));
                var numerics = Numerics.Where(n => languages.Any(l => n.Name == l.Numeric));
                foreach (var alpha in alphabets)
                {
                    foreach (var numeric in numerics)
                    {
                        try
                        {
                            // generate forward gematria
                            var gematria = new Gematria();
                            gematria.Name = alpha.Name + numeric.Name;
                            gematria.Geometric = numeric.Geometric;
                            gematria.Arithmetic = numeric.Arithmetic;
                            for (var i = 0; i < alpha.Chars.Count; i++)
                            {
                                var key = alpha.Chars[i];
                                var val = numeric.Series[i];
                                gematria.Pairs.Add(key, val);
                            }
                            Gematrias.Add(gematria);
                            //generate reverse gematria
                            if (canreverse)
                            {
                                gematria = new Gematria();
                                gematria.Name = "Rev" + alpha.Name + numeric.Name;
                                gematria.Geometric = numeric.Geometric;
                                gematria.Arithmetic = numeric.Arithmetic;
                                var shift = Math.Abs(numeric.Series.Count - alpha.Chars.Count);
                                for (var i = 0; i < alpha.Chars.Count; i++)
                                {
                                    var key = alpha.Chars[i];
                                    var val = numeric.Reverses[i + shift];
                                    gematria.Pairs.Add(key, val);
                                }
                                Gematrias.Add(gematria);
                            }
                        }
                        catch { }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR GenerateGematria() " + err);
            }
        }

        public List<GemResult> CalculateGematria(string men_name, string cases="Upper")
        {
            GemResults = new List<GemResult>();
            try
            {
                // no whitespace and special char
                men_name = CheckName(men_name, cases);
                foreach (var gem in Gematrias)
                {
                    try
                    {
                        // set default value
                        int n = men_name.Length;
                        var result = new GemResult();
                        result.Gematria = gem.Name;
                        result.Initial = 0;
                        result.Adder = 0;
                        result.Multiplier = 1;
                        result.Final = 0;
                        // calculate initial value
                        foreach (var chr in men_name)
                        {
                            try
                            {
                                result.Initial = result.Initial + gem.Pairs[chr];
                            }
                            catch { }
                        }
                        // find multiplier
                        if (gem.Geometric && (antiChrist > result.Initial) && (antiChrist % result.Initial) == 0)
                        {
                            result.Multiplier = antiChrist / result.Initial;
                        }
                        else
                        {
                            // find adder
                            if ((n != 0) && gem.Arithmetic && (antiChrist > result.Initial) && ((antiChrist - result.Initial) % n) == 0)
                            {
                                result.Adder = (antiChrist - result.Initial) / n;
                            }
                        }
                        // calculate final value
                        foreach (var chr in men_name)
                        {
                            try
                            {
                                result.Final = result.Final + (gem.Pairs[chr] + result.Adder) * result.Multiplier;
                            }
                            catch { }
                        }
                        GemResults.Add(result);
                    }
                    catch { }
                }
                GemResults = GemResults.OrderByDescending(r => r.Final).ToList();
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR CalculateGematria() " + err);
            }
            return GemResults;
        }

        public List<GemSystem> SelectGematria(string gem_name)
        {
            GemSystems = new List<GemSystem>();
            try
            {
                var gem = Gematrias.Where(r => r.Name == gem_name).First();
                var res = GemResults.Where(r => r.Gematria == gem_name).First();
                foreach (var pair in gem.Pairs)
                {
                    GemSystems.Add(new GemSystem(pair.Key, (pair.Value+ res.Adder)*res.Multiplier));
                }
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR SelectGematria() " + err);
            }
            return GemSystems;
        }

        public List<GemMethod> SelectMethod(string gem_name, string men_name, string cases="Upper")
        {
            GemMethods = new List<GemMethod>();
            try
            {
                // no whitespace and special char
                men_name = CheckName(men_name, cases);
                var gem = Gematrias.Where(r => r.Name == gem_name).First();
                var res = GemResults.Where(r => r.Gematria == gem_name).First();
                foreach (var chr in men_name)
                {
                    GemMethods.Add(new GemMethod(Convert.ToString(chr), (gem.Pairs[chr]+res.Adder)*res.Multiplier));
                }
                GemMethods.Add(new GemMethod("TOTAL", res.Final));
            }
            catch (Exception err)
            {
                Console.WriteLine("ERROR SelectMethod() " + err);
            }
            return GemMethods;
        }
    }
}
