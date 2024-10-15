using System.Text.RegularExpressions;

namespace TextAnalyzer.Utility
{
    public class StringAppearances
    {
        public Boolean verify_word(String inputWord, String inputSentence)
        {
            Boolean result = false;

            if (string.IsNullOrWhiteSpace(inputWord) || string.IsNullOrWhiteSpace(inputSentence))
            {
                return result;
            }
            else
            {
                string pattern = $@"{Regex.Escape(inputWord)}";
                result = Regex.IsMatch(inputSentence, pattern, RegexOptions.IgnoreCase);
            }

            return result;
        }

        public Boolean verify_words(String inputWords, String inputSentence)
        {
            Boolean result = false;

            if (string.IsNullOrWhiteSpace(inputWords) || string.IsNullOrWhiteSpace(inputSentence))
            {
                return false;
            }
            else
            {
                var wordsToVerify = inputWords
                    .Split(',')
                    .Select(word => word.Trim())
                    .ToArray();

                foreach (var word in wordsToVerify)
                {
                    if (!verify_word(word, inputSentence))
                    {
                        return false;
                    }
                    else
                    {
                        result = true;
                    }
                }
                return result;
            }

        }

    }
}
