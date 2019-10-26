using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLanger.Data
{
    [Serializable]
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

    [Serializable]
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

    [Serializable]
    public class SyllableStructure
    {
        public SyllableStructure(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }

    [Serializable]
    public class WordType
    {
        public string Name { get; set; }

        public WordType(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class Word
    {
        public Word(List<Phoneme> iPA, string meaning, WordType type)
        {
            IPA = iPA;
            Meaning = meaning;
            Type = type;
            Variations = new List<Word>();
            Etymology = new List<Word>();
        }

        public List<Phoneme> IPA { get; set; }
        public string Meaning { get; set; }

        public WordType Type { get; set; }

        public List<Word> Variations { get; set; }
        public List<Word> Etymology { get; set; }
    }
}
