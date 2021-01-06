using System;
using System.Text.RegularExpressions;

namespace GenerateSlug
{
    static class Program
    {
        static void Main(string[] args)
        {
            string[] names = new[]
            {
                "1 Feet - Aluminium 5W Led Square Tubelight (SCTA)",
                "2 Feet - Aluminium 5W Led Square Tubelight (SCTA)",
                "4 Feet - Aluminium 20W Led Square Tubelight (SCTA)",
                "4 Feet - Aluminium 36W Battonfit Led Tubelight (SVTB)",
                "4 Feet - Plasto 20W Square Led Tubelight (SCTP)",
                "2 Feet - Plasto 10W Square Led Tubelight (SCTP)",
                "1 Feet - Plasto 5W Square Led Tubelight (SCTP)",
                "4 Feet - Retrofit 20W Led Tubelight (SMTR)",
                "2 Feet - Retrofit 10W Led Tubelight (SMTR)",
                "12W - SS (S)",
                "20W - SS (S)",
                "20W - SAE (S)",
                "24W - SS (S)",
                "24W - SAE (S)",
                "24W - SC (S)",
                "30W - SCS (S)",
                "30W - SC (S)",
                "36W - SCS (S)",
                "36W - SC (S)",
                "42W - SC (S)",
                "50W - SCS (S)",
                "50W - SCE (S)",
                "60W SCE (S)",
                "60W SCS (S)",
                "72W SCE (S)",
                "90W SCE (S)",
                "100W SC (S)",
                "120W SC (S)",
                "150W SC (S)",
                "150W SCB (S)",
                "72W SCB (S)",
                "100W SCB (S)",
                "120W SCB (S)",
                "200W SCB (S)",
                "250W SVB (S)",
            };

            foreach (var name in names)
            {
                Console.WriteLine(name.GenerateSlug());
            }

        }

        public static string GenerateSlug(this string phrase, int limit = 50)
        {
            if (phrase == null)
                return null;

            string str = phrase.ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();

            // cut and trim 
            if (limit < 0)
                limit = 50;
            str = str.Substring(0, str.Length <= limit ? str.Length : limit).Trim();

            str = Regex.Replace(str, @"\s", "-"); // hyphens   
            return str;
        }

        private static string RemoveAccent(this string txt)
        {
            if (txt == null)
                return null;

            byte[] bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(txt);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
    }

    
}
