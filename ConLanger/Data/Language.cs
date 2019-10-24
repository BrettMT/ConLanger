using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLanger.Data
{
    public class Language
    {
        public Language(string name)
        {
            Name = name;
            Phonemes = new List<Phoneme>();
            Syllables = new List<SyllableStructure>();
            Words = new List<Word>();
            WordTypes = new List<WordType>();
        }

        public string Name { get; set; }

        public List<Phoneme> Phonemes { get; set;}
        public List<SyllableStructure> Syllables { get; set; }
        public List<Word> Words { get; set;}
        public List<WordType> WordTypes { get; set; }
    }

    public class Phoneme
    {
        public Phoneme(string iPA, string roman, int weight, string syllableCode)
        {
            IPA = iPA;
            Roman = roman;
            Weight = weight;
            SyllableCode = syllableCode;
        }

        public string IPA { get; set; }
        public string Roman { get; set; }
        public int Weight { get; set; }
        public string SyllableCode { get; set;}
    }

    public class SyllableStructure
    {
        public SyllableStructure(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }

    public class WordType
    {
        public string Name;

        public WordType(string name)
        {
            Name = name;
        }
    }

    public class Word
    {
        public Word(string iPA, string roman, string meaning, string example, WordType type)
        {
            IPA = iPA;
            Roman = roman;
            Meaning = meaning;
            Example = example;
            Type = type;
            Variations = new List<Word>();
            Etymology = new List<Word>();
        }

        public string IPA { get; set; }
        public string Roman { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }

        public WordType Type { get; set; }

        public List<Word> Variations { get; set; }
        public List<Word> Etymology { get; set; }
    }
}
