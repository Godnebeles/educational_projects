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

            string[] words = text.ToLower().Split(new char[] { ' ', '\t', ':', '?', '!', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(var word in words)
            {
                if (wordsInfo.ContainsKey(word))
                    wordsInfo[word] = wordsInfo[word] + 1;
                else
                    wordsInfo.Add(word, 1);
            }

            return wordsInfo;
        }
    }


}
