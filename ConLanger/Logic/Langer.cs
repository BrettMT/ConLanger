using ConLanger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLanger.Logic
{
    public class Langer
    {
        //Currently 10/22 a new Language is made when you use the Create Language button otherwise this is just null. TODO: Be able to to load saved languages.

        //TODO: Nothing other than LanguageName checks if language is null when it tries to use it. Language defaults to null and is not set unless Create or Load language actions take place.
        internal Language Language;

        public event EventHandler ChangedLanguages;
        public event EventHandler ChangedPhonemes;
        public event EventHandler ChangedWordTypes;


        public string LanguageName
        {
            get
            {
                //Quick null check, if no language then return that text otherwise use the name.
                return Language?.Name ?? "No Language Selected";
            }
        }
        public List<Phoneme> Phonemes
        {
            get => Language?.Phonemes ?? throw new NullReferenceException("a Language has not been loaded"); 
        }

        public List<WordType> WordTypes
        {
            get => Language?.WordTypes ?? throw new NullReferenceException("a Language has not been loaded");
        }

        public void CreateLangauge(string name)
        {
            Language = new Language(name);
            ChangedLanguages.Invoke(this, null);
        }

        #region Word Type Functions
        public void AddWordType(string name)
        {
            if (Language == null) throw new UnableToModifyLanguageException("There is no language set");
            Language.WordTypes.Add(new WordType(name));
            if (ChangedWordTypes != null) ChangedWordTypes.Invoke(this, null);
        }

        public void RemoveWordType(WordType wordType)
        {
            if (Language == null) throw new UnableToModifyLanguageException("There is no language set");
            Language.WordTypes.Remove(wordType);
            if (ChangedWordTypes != null) ChangedWordTypes.Invoke(this, null);
        }
        #endregion

        #region Phoneme functions
        public void AddPhoneme(string iPA, string roman, int weight, string syllableCode)
        {
            if (Language == null) throw new UnableToModifyLanguageException("There is no language set");
            Language.Phonemes.Add(new Phoneme(iPA, roman, weight, syllableCode));
            if(ChangedPhonemes != null) ChangedPhonemes.Invoke(this, null);
        }
       
        public void EditPhoneme(Phoneme selected, string iPA, string roman, int weight, string syllableCode)
        {
            if (Language == null) throw new UnableToModifyLanguageException("There is no language set");
            selected.IPA = iPA;
            selected.Roman = roman;
            selected.Weight = weight;
            selected.SyllableCode = syllableCode;
            if (ChangedPhonemes != null) ChangedPhonemes.Invoke(this, null);
        }

        public void RemovePhoneme(Phoneme selected)
        {
            if (Language == null) throw new UnableToModifyLanguageException("There is no language set");
            Language.Phonemes.Remove(selected);
            if (ChangedPhonemes != null) ChangedPhonemes.Invoke(this, null);
        }
        #endregion

        public void AddSyllableStructure(string code)
        {
            Language.Syllables.Add(new SyllableStructure(code));
        }

        public void AddWord(string iPA, string roman, string meaning, string example, WordType type)
        {
            Language.Words.Add(new Word(iPA, roman, meaning, example, type));
        }
    }

    public class UnableToModifyLanguageException : Exception
    {
        public UnableToModifyLanguageException(string message) : base(message)
        {
        }
    }
}
