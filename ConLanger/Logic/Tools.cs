using ConLanger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConLanger.Logic
{
    public static class Tools
    {
        static public List<Phoneme> ConvertStringToPhoneList(string text, Langer L)
        {
            List<Phoneme> word = new List<Phoneme>();

            //First convert the text whose phones should be delenated by spaces into an array of strings.
            string[] Phones = text.Split(' ');

            //Iterate over the strings and use the Langer to get the appriopriote Phoneme.
            foreach(string s in Phones)
            {
                //Add the return Phoneme to the list.
                word.Add(L.FindPhonemeByIPA(s));
            }

            //Now return the final list.
            return word;
            
        }
    }
}
