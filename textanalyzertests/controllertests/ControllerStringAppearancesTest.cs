using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Legacy;
using TextAnalyzer.controllers;

namespace TextAnalyzer.controllertests
{
    public class ControllerStringAppearancesTest
    {
        private ControllerStringAppearances controllerStringAppearances;

        [SetUp]
        public void SetUp()
        {
            controllerStringAppearances = new ControllerStringAppearances();
        }
        
        [Test]
        public void checkIfControllerStringAppearancesCanBeCreated()
        {
            ClassicAssert.NotNull(controllerStringAppearances);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordNotGivenString()
        {
            String testWord = "";
            String testSentence = "OneWouldSayTheUniverseConsistALotOfTheMilkyWay";
            var result = controllerStringAppearances.verifyWord(testWord, testSentence) as BadRequestObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(400, result.StatusCode);
            ClassicAssert.AreEqual("Message cannot be empty.", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordGivenString()
        {
            String testWord = "TheMilkyWay";
            String testSentence = "OneWouldSayTheUniverseConsistALotOfTheMilkyWay";
            var result = controllerStringAppearances.verifyWord(testWord, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordInMiddleString()
        {
            String testWord = "TheMilkyWay";
            String testSentence = "OneWouldSayTheUniverseTheMilkyWayConsistALotOf";
            var result = controllerStringAppearances.verifyWord(testWord, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordInBeginOfString()
        {
            String testWord = "TheMilkyWay";
            String testSentence = "TheMilkyWayOneWouldSayTheUniverseConsistALotOf";
            var result = controllerStringAppearances.verifyWord(testWord, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordInSentenceSeparatedBySpaces()
        {
            String testWord = "Way";
            String testSentence = "The Milky Way One Would Say The Universe Consist A Lot Of";
            var result = controllerStringAppearances.verifyWord(testWord, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordInSentenceSeparatedByCommaDelimeters()
        {
            String testWord = "Way";
            String testSentence = "The,Milky,Way,One,Would,Say,The,Universe,Consist,A,Lot,Of";
            var result = controllerStringAppearances.verifyWord(testWord, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesManyWordsInSentenceSeparatedByCommaDelimeters()
        {
            String testWords = "Way,Universe";
            String testSentence = "The,Milky,Way,One,Would,Say,The,Universe,Consist,A,Lot,Of";
            var result = controllerStringAppearances.verifyWords(testWords, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesManyWordsInSentenceSeparatedBySpaces()
        {
            String testWords = "Say,Of,Consist";
            String testSentence = "Would Say The Universe Consist A Lot Of";
            var result = controllerStringAppearances.verifyWords(testWords, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesManyWordsInSentenceSeparatedByQuestionsDelimiter()
        {
            String testWords = "congress,hearing,faces";
            String testSentence = "New?elected?president?faces?congress?hearing";
            var result = controllerStringAppearances.verifyWords(testWords, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesOneWordMissingInTheSentenceSeparatedByQuestionDelimiter()
        {
            String testWords = "congress,hearing,faces";
            String testSentence = "New?elected?president?faces?hearing";
            var result = controllerStringAppearances.verifyWords(testWords, testSentence) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("False", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesLetterOccureInGivenWord()
        {
            Char letter = 'U';
            String word = "USA";
            var result = controllerStringAppearances.verifyLetter(letter, word) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesLetterNotOccureInGivenWord()
        {
            Char letter = 'B';
            String word = "USA";
            var result = controllerStringAppearances.verifyLetter(letter, word) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("False", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesLettersOccureInGivenWord()
        {
            String letters = "M,A,G,A";
            String word = "MakeAmericaGreatAgain";
            var result = controllerStringAppearances.verifyLetters(letters, word) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesNotAllLettersOccureInGivenWord()
        {
            String letters = "M,Z";
            String word = "MakeAmericaGreatAgain";
            var result = controllerStringAppearances.verifyLetters(letters, word) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("False", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerStringAppearancesNoLettersInGivenWord()
        {
            String letters = "";
            String word = "MakeAmericaGreatAgain";
            var result = controllerStringAppearances.verifyLetters(letters, word) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("False", ((dynamic)result.Value).EchoedMessage);
        }
    }
}
