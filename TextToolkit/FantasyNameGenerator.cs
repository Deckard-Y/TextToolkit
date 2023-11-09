using System;
using System.Collections.Generic;
using System.Text;

namespace TextToolkit
{
    public class FantasyNameGenerator
    {
        private readonly Random _random = new Random();
        private readonly List<string> _prefixes = new List<string> { "Zar", "Ny", "Az", "Thro", "R'lye", "Kad", "Xoth" };
        private readonly List<string> _infixes = new List<string> { "atho", "gha", "nach", "thog", "quan", "lu", "thul" };
        private readonly List<string> _suffixes = new List<string> { "aq", "ith", "on", "th", "os", "um", "oh" };

        private readonly Dictionary<string, string> _transliterationTable = new Dictionary<string, string>
    {
        {"a", "ア"}, {"b", "ブ"}, {"c", "ク"}, {"d", "ド"}, {"e", "エ"},
        {"f", "フ"}, {"g", "グ"}, {"h", "ハ"}, {"i", "イ"}, {"j", "ジ"},
        {"k", "ク"}, {"l", "ル"}, {"m", "ム"}, {"n", "ン"}, {"o", "オ"},
        {"p", "プ"}, {"q", "ク"}, {"r", "ラ"}, {"s", "ス"}, {"t", "ト"},
        {"u", "ウ"}, {"v", "ヴ"}, {"w", "ウ"}, {"x", "クス"}, {"y", "イ"},
        {"z", "ズ"}, {"th", "ス"}, {"gh", "ガ"}, {"ph", "フ"}, {"sh", "シ"},
        {"ch", "チ"}, {"ou", "オウ"}, {"oo", "ウ"}, {"ee", "イー"},{"K","カ"},{"N","ナ"},{"T","タ"},{"A","ア"},
        {"Th","ス"}
    };

        public string GenerateName()
        {
            var prefix = _prefixes[_random.Next(_prefixes.Count)];
            var infix = _infixes[_random.Next(_infixes.Count)];
            var suffix = _suffixes[_random.Next(_suffixes.Count)];
            var includeInfix = _random.Next(0, 2) == 0;
            var name = includeInfix ? $"{prefix}{infix}{suffix}" : $"{prefix}{suffix}";
            return $"{name} ({TransliterateToKatakana(name)})";
        }

        private string TransliterateToKatakana(string name)
        {
            StringBuilder katakanaName = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                string character = name.Substring(i, i + 1 < name.Length && _transliterationTable.ContainsKey(name.Substring(i, 2)) ? 2 : 1);
                katakanaName.Append(_transliterationTable.ContainsKey(character) ? _transliterationTable[character] : character);
                i += character.Length - 1;
            }
            return katakanaName.ToString();
        }
    }
}