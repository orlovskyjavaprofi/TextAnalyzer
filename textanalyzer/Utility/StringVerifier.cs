using System.Diagnostics.Metrics;
using System.Text;
using System.Text.RegularExpressions;

namespace TextAnalyzer.Utility
{
    public class StringVerifier
    {
        public int count_words_in_string(string input)
        {

            int result_of_counted_words = ident_words(input).Length;
            if (result_of_counted_words == 0)
            {
                return 0;
            }
            else
            {
                return result_of_counted_words;
            }
        }

        private string[] ident_words(string input)
        {

            if (!string.IsNullOrEmpty(input))
            {
                string pattern = @"(?<!^)(?=[A-Z])|[ ,;.!?'\t\n]+";
                var words = Regex.Split(input, pattern)
                    .Where(word => !string.IsNullOrWhiteSpace(word))
                    .Select(word => word.Trim())
                    .ToArray();
                return words;
            }
            else
            {
                string[] words = new string[0];
                return words;
            }
        }

        public int count_letter_in_word(Char inputLetter, String inputWord)
        {
            int count = 0;

            if (string.IsNullOrEmpty(inputWord))
            {
                return 0;
            }

            foreach (char charInWord in inputWord)
            {
                
                if (char.ToLower(charInWord) == char.ToLower(inputLetter))
                {
                    count++;
                }
            }

            return count;

        }

        public String count_many_letter_in_word(String inputLetters, String givenInput)
        {
            int totalFoundLetters = 0;
            String result = "Invalid input!";

            if (string.IsNullOrEmpty(inputLetters) || string.IsNullOrEmpty(givenInput))
            {
                return result;
            }
            else
            {
                StringBuilder resultBuilder = new StringBuilder();

                foreach (char letter in inputLetters)
                {
                    int count = count_letter_in_word(letter, givenInput);

                    if (count > 0)
                    {
                        resultBuilder.Append($"{letter}: {count}, ");
                        totalFoundLetters++;
                    }
           
                }

                if (resultBuilder.Length > 0)
                {                 
                    resultBuilder.Length -= 2;
                }

                resultBuilder.Append($", found: {totalFoundLetters} letters!");
                result = resultBuilder.ToString();
                
            }
            return result;

        }
    }
}
