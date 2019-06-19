using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCs.Models
{



    public class LetterQuiz
    {
        private readonly int numberOfLetters = 2;
        private readonly Random rng;
        private readonly Random shuffler;

        public List<char> Alphabet {get; private set;}
        public List<char> AllLetters {get; private set;}
        public char Answer {get; private set;}
        public int AnswerIndex => AllLetters.FindIndex(x => x == Answer);

        public LetterQuiz()
        {
            Alphabet = new List<char>() {'A', 'C', 'F', 'H', 'I', 'O'};
            rng = new Random();
            shuffler = new Random();

            Answer = RandomAnswer();
            AllLetters = RandomLetters(Answer);
        }

        private char RandomAnswer()
        {
            var max = Alphabet.Count() - 1;

            return Alphabet[rng.Next(0, max)];
        }


        // Removing the answer so that the generated pictures won't be duplicates.
        private List<char> RandomLetters(char answer)
        {
            Alphabet.Remove(answer);
            var result = new List<char> {answer};

            for (int i = 0; i < numberOfLetters; i++)
            {
                var index = rng.Next(0, Alphabet.Count - 1);
                var letter = Alphabet[index];
                Alphabet.RemoveAt(index);
                result.Add(letter);
            }

            return Shuffle(result);
        }

        private List<T> Shuffle<T>(List<T> list)
        {
            int n = list.Count();
            
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