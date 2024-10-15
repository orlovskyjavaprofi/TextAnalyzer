using NUnit.Framework.Legacy;
using TextAnalyzer.Utility;

namespace TextAnalyzer.utilitytests
{
    public class StringAppearancesTest
    {
        private StringAppearances strAppearances;

        [SetUp]
        public void Setup()
        {
            strAppearances = new StringAppearances();
        }


        [Test]
        public void checkIfStringAppearancesCanBeCreatd()
        {
            ClassicAssert.NotNull(strAppearances);
        }

        [Test]
        public void checkIfOneWordNotGivenInGivenSentence()
        {
            String testWord = "";
            String testSentence = "OneWouldSayTheUniverseConsistALotOfTheMilkyWay";

            ClassicAssert.False(strAppearances.verify_word(testWord, testSentence));
        }

        [Test]
        public void checkIfOneWordAppearsInGivenWord()
        {
            String testWord = "TheMilkyWay";
            String testSentence = "OneWouldSayTheUniverseConsistALotOfTheMilkyWay";

            ClassicAssert.True(strAppearances.verify_word(testWord, testSentence));
        }

        [Test]
        public void checkIfOneWordAppearsInMiddleGivenSentence()
        {
            String testWord = "TheMilkyWay";
            String testSentence = "OneWouldSayTheUniverseTheMilkyWayConsistALotOf";

            ClassicAssert.True(strAppearances.verify_word(testWord, testSentence));
        }

        [Test]
        public void checkIfOneWordAppearsInBeginOfGivenSentence()
        {
            String testWord = "TheMilkyWay";
            String testSentence = "TheMilkyWayOneWouldSayTheUniverseConsistALotOf";

            ClassicAssert.True(strAppearances.verify_word(testWord, testSentence));
        }

        [Test]
        public void checkIfOneWordAppearsInSentenceSeparatedBySpaces()
        {
            String testWord = "Way";
            String testSentence = "The Milky Way One Would Say The Universe Consist A Lot Of";

            ClassicAssert.True(strAppearances.verify_word(testWord, testSentence));
        }

        [Test]
        public void checkIfOneWordAppearsInSentenceSeparatedByCommaDelimeters()
        {
            String testWord = "Way";
            String testSentence = "The,Milky,Way,One,Would,Say,The,Universe,Consist,A,Lot,Of";

            ClassicAssert.True(strAppearances.verify_word(testWord, testSentence));
        }

        [Test]
        public void checkIfManyWordsAppearingInTheSentenceSeparatedByCommaDelimeters()
        {
            String testWords = "Way,Universe";
            String testSentence = "The,Milky,Way,One,Would,Say,The,Universe,Consist,A,Lot,Of";

            ClassicAssert.True(strAppearances.verify_words(testWords, testSentence));
        }

        [Test]
        public void checkIfManyWordsAppearingInTheSentenceSeparatedBySpaces()
        {
            String testWords = "Say,Of,Consist";
            String testSentence = "Would Say The Universe Consist A Lot Of";

            ClassicAssert.True(strAppearances.verify_words(testWords, testSentence));
        }

        [Test]
        public void checkIfManyWordsAppearingInTheSentenceSeparatedByQuestionDelimiter()
        {
            String testWords = "congress,hearing,faces";
            String testSentence = "New?elected?president?faces?congress?hearing";

            ClassicAssert.True(strAppearances.verify_words(testWords, testSentence));
        }

        [Test]
        public void checkIfOneWordMissingInTheSentenceSeparatedByQuestionDelimiter()
        {
            String testWords = "congress,hearing,faces";
            String testSentence = "New?elected?president?faces?hearing";

            ClassicAssert.False(strAppearances.verify_words(testWords, testSentence));
        }
    }
}
