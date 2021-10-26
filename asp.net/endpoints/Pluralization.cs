using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace endpoints
{
    public class Pluralization
    {
        public static string PolirazationWord(int number, string[] words)
        {
                if (number % 100 == 0 || (number % 100 > 4 && number % 100 < 21))
                {   
                    return words[2];            
                }
                else if(number % 100 == 1 )
                {
                    return words[0];
                } 
                else
                {
                    return words[1];
                }
   
                throw new Exception("Not condition for this number :(");   
        }

    }
}