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
    }
}
