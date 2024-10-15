using NUnit.Framework.Legacy;
using TextAnalyzer.Utility;

namespace TextAnalyzer.utilitytests
{
    public class StringVerifierTest
    {
        private StringVerifier strVerfier;

        [SetUp]
        public void Setup()
        {
            strVerfier = new StringVerifier();
        }

        [Test]
        public void checkIfStringVerfierCanBeCreatd()
        {
            ClassicAssert.NotNull(strVerfier);
        }

        [Test]
        public void checkCountOneWordInGivenString()
        {
            int countedWords = 1;
            String givenInput = "test";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }


        [Test]
        public void checkCountManyWordsInGivenString()
        {
            int countedWords = 5;
            String givenInput = "testALikeManyWords";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }

        [Test]
        public void checkCountManyWordsSeparatedByComaInAString()
        {
            int countedWords = 5;
            String givenInput = "test,A,Like,Many,Words";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }

        [Test]
        public void checkCountManyWordsSeparatedBySemicolonInAString()
        {
            int countedWords = 5;
            String givenInput = "test;A;Like;Many;Words";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }

        [Test]
        public void checkCountManyWordsSeparatedByQuestionMarkInAString()
        {
            int countedWords = 5;
            String givenInput = "test?A?Like?Many?Words";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }

        [Test]
        public void checkCountManyWordsSeparatedByExclamationMarkInAString()
        {
            int countedWords = 5;
            String givenInput = "test!A!Like!Many!Words";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }


        [Test]
        public void checkCountManyWordsSeparatedByDifferentSignsInAString()
        {
            int countedWords = 6;
            String givenInput = "test'A;Like!Many?Words Test2";
            ClassicAssert.AreEqual(countedWords, strVerfier.count_words_in_string(givenInput));
        }

    }
}
