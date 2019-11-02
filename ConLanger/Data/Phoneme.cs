using System;

namespace ConLanger.Data
{
    [Serializable]
    public class Phoneme
    {
        public Phoneme(string typedCharacter, string iPA, string roman, int weight, string syllableCode)
        {
            TypedChar = typedCharacter; 
            IPA = iPA;
            Roman = roman;
            Weight = weight;
            SyllableCode = syllableCode;
        }

        public void Edit(string typedCharacter, string iPA, string roman, int weight, string syllableCode)
        {
            TypedChar = typedCharacter;
            IPA = iPA;
            Roman = roman;
            Weight = weight;
            SyllableCode = syllableCode;
        }

        public string TypedChar { get; set; }
        public string IPA { get; set; }
        public string Roman { get; set; }
        public int Weight { get; set; }
        public string SyllableCode { get; set;}
    }
}
