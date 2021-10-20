using System;
using System.Collections.Generic;

namespace word_frequency
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Привет, человек, как дела твои, человек? Прощай, человек...";

            Dictionary<string, int> wordsInfo = GetInfoAboutWords(text);

            foreach (KeyValuePair<string, int> keyValue in wordsInfo)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value);
            }
        }

        public static Dictionary<string, int> GetInfoAboutWords(string text)
        {
            Dictionary<string, int> wordsInfo = new Dictionary<string, int>();

            string[] words = text.Split(new char[] { ' ', '\t', ':', '?', '!', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (wordsInfo.ContainsKey(words[i].ToLower()))
                    wordsInfo[words[i].ToLower()] = wordsInfo[words[i].ToLower()] + 1;
                else
                    wordsInfo.Add(words[i].ToLower(), 1);
            }

            return wordsInfo;
        }
    }


}
