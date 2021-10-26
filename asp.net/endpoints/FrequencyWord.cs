using System;
using System.Collections.Generic;

namespace endpoints
{
    class FrequencyWord
    {


        public static Dictionary<string, int> GetInfoAboutWords(string text)
        {
            Dictionary<string, int> wordsInfo = new Dictionary<string, int>();

            string[] words = text.ToLower().Split(new char[] { ' ', '\t', ':', '?', '!', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (wordsInfo.ContainsKey(word))
                    wordsInfo[word] = wordsInfo[word] + 1;
                else
                    wordsInfo.Add(word, 1);
            }

            return wordsInfo;
        }

        public static string GetMostFreqWord(Dictionary<string, int> words)
        {
            string maxFreqWord = "";
            int max = 0;
            foreach (KeyValuePair<string, int> keyValue in words)
            {
                if (max < keyValue.Value)
                {
                    maxFreqWord = keyValue.Key;
                    max = keyValue.Value;
                }
            }
            return maxFreqWord;
        }
    }


}