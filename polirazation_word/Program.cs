using System;

namespace polirazation_word
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine(PolirazationWord(1, new string[3] {"клавиатура", "клавиатуры", "клавиатур"}));
            System.Console.WriteLine(PolirazationWord(2, new string[3] {"клавиатура", "клавиатуры", "клавиатур"}));
            System.Console.WriteLine(PolirazationWord(300, new string[3] {"клавиатура", "клавиатуры", "клавиатур"}));
            
            System.Console.WriteLine(PolirazationWord(1, new string[3] {"арбуз", "арбуза", "арбузов"}));
            System.Console.WriteLine(PolirazationWord(2, new string[3] {"арбуз", "арбуза", "арбузов"}));
            System.Console.WriteLine(PolirazationWord(10, new string[3] {"арбуз", "арбуза", "арбузов"}));

            System.Console.WriteLine(PolirazationWord(1, new string[3] {"монета", "монеты", "монет"}));
            System.Console.WriteLine(PolirazationWord(2, new string[3] {"монета", "монеты", "монет"}));
            System.Console.WriteLine(PolirazationWord(311, new string[3] {"монета", "монеты", "монет"}));
        }

       

        static string PolirazationWord(int number, string[] words)
        {
                if (number % 100 == 0)
                {   
                    return words[2];            
                }
                else if(number % 100 == 1 )
                {
                    return words[0];
                } 
                else if(number % 10 == 2)
                {
                    return words[1];
                }
		        else if(number % 100 > 1 && number % 100 < 5 )
                {
                    return words[1];
                }
                else if(number % 100 > 4 && number % 100 < 21)
                {
                    return words[2];
                }
                throw new Exception("Not condition for this number :(");   
        }

    }
}
