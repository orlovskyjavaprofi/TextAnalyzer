using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Legacy;
using TextAnalyzer.controllers;

namespace TextAnalyzer.controllertests
{
    public class ControllerStringVerifierTest
    {
        private ControllerStringVerifier controllerVerifier;

        [SetUp]
        public void SetUp()
        {
            controllerVerifier = new ControllerStringVerifier();
        }

        [Test]
        public void checkIfStringVerfierCanBeCreated()
        {
            ClassicAssert.NotNull(controllerVerifier);
        }

        [Test]
        public void checkControllerStringVerifierOneWordInGivenString()
        {
            var result = controllerVerifier.countWords("Test") as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("1", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierManyWordsInGivenString()
        {
            var result = controllerVerifier.countWords("testALikeManyWords") as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("5", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierManyWordsSeparatedByComaInAString()
        {
            var result = controllerVerifier.countWords("test,A,Like,Many,Words") as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("5", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierManyWordsSeparatedBySemicolonInAString()
        {
            var result = controllerVerifier.countWords("test;A;Like;Many;Words") as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("5", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierWordsSeparatedByQuestionMarkInAString()
        {
            var result = controllerVerifier.countWords("test?A?Like?Many?Words") as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("5", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierManyWordsSeparatedByExclamationMarkInAString()
        {
            var result = controllerVerifier.countWords("test'A;Like!Many?Words Test2") as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("6", ((dynamic)result.Value).EchoedMessage);
        }


        [Test]
        public void checkControllerStringVerifierOneLetterInGivenWord()
        {
            String givenInput = "Transformers";
            var result = controllerVerifier.countLetter('T', givenInput) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("1", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierOneLetterNotAppearInGivenWord()
        {
            String givenInput = "Transformers";
            var result = controllerVerifier.countLetter('B', givenInput) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("0", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierManyLettersInGivenWord()
        {
            String givenInput = "Testopia";
            var result = controllerVerifier.countManyLetters("T,s,e", givenInput) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("T: 2, s: 1, e: 1, found: 3 letters!", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierErrorMessageIfCountManyLettersInGivenEmptyWord()
        {
            String givenInput = "";
            var result = controllerVerifier.countManyLetters("T,s,e", givenInput) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("Invalid input!", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierCheckForB64Code()
        {
            String givenInput = "d7UTz8x29Xny7GyQqy2fUQ==";
            var result = controllerVerifier.verifyB64Code(givenInput) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierNoB64Code()
        {
            String givenInput = "I am not 64bit coded string!";
            var result = controllerVerifier.verifyB64Code(givenInput) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("False", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierValidEmail()
        {
            String givenEmail = "valid@gmail.com";
            var result = controllerVerifier.validateEmail(givenEmail) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("True", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierNotValidEmail()
        {
            String givenEmail = "valid@faker.com";
            var result = controllerVerifier.validateEmail(givenEmail) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual("False", ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkControllerStringVerifierEmptyEmail()
        {
            String givenEmail = "";
            var result = controllerVerifier.validateEmail(givenEmail) as BadRequestObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(400, result.StatusCode);
            ClassicAssert.AreEqual("Message cannot be empty.", ((dynamic)result.Value).EchoedMessage);
        }
    }
}
