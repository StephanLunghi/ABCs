using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCs.Models
{
    public class LetterQuiz
    {
        private readonly int numberOfLetters = 3;
        private readonly Random rng;
        private readonly Random shuffler;

        public List<char> KnownLetters {get; private set;}
        public IEnumerable<char> AllLetters {get; private set;}
        public char Answer {get; private set;}

        public LetterQuiz()
        {
            KnownLetters = new List<char>() {'A', 'C', 'F', 'H', 'I', 'O'};
            rng = new Random();
            shuffler = new Random();

            Answer = RandomAnswer();
            AllLetters = RandomLetters(Answer);
        }

        private char RandomAnswer()
        {
            var max = KnownLetters.Count() - 1;

            return KnownLetters[rng.Next(0, max)];
        }

        private IEnumerable<char> RandomLetters(char answer)
        {
            var max = KnownLetters.Count() - 1;
            var result = new IEnumerable<char>(){ answer };

            for (int i = 0; i < numberOfLetters; i++)
            {
                result.Append(KnownLetters[rng.Next(0, max)]);
            }

            return result.Shuffle();
        }

        private IEnumberable<T> Shuffle<T>(this IEnumerable<T> list)  
        {  
            int n = list.Count;  
            while (n > 1) 
            {  
                n--;  
                int k = shuffler.Next(n + 1);  
                T value = list[k];  
                list[k] = list[n];  
                list[n] = value;  
            }

            return list;  
        }
    }
}