
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Legacy;
using TextAnalyzer.controllers;

namespace TextAnalyzer.controllertests
{
    public class ControllerDecimalFormaterTest
    {
        private ControllerDecimalFormater controllerDecimalFormater;

        [SetUp]
        public void SetUp()
        {
            controllerDecimalFormater = new ControllerDecimalFormater();
        }

        [Test]
        public void checkIfDecimalFormaterCanBeCreated()
        {
            ClassicAssert.NotNull(controllerDecimalFormater);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat1()
        {
            String inputNumber = "1500,3025";
            String expectedNumber = "1500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat2()
        {
            String inputNumber = "1500.3025";
            String expectedNumber = "1500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat3()
        {
            String inputNumber = "1500, 3025";
            String expectedNumber = "1500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat4()
        {
            String inputNumber = "1500. 3025";
            String expectedNumber = "1500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat5()
        {
            String inputNumber = "1500,00302500";
            String expectedNumber = "1500,00302500";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat6()
        {
            String inputNumber = "1500.00302500";
            String expectedNumber = "1500,00302500";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat7()
        {
            String inputNumber = "1,500.3025";
            String expectedNumber = "1500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat8()
        {
            String inputNumber = "1.500.3025";
            String expectedNumber = "1500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat9()
        {
            String inputNumber = "1,600,500.3025";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }


        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat10()
        {
            String inputNumber = "1.600,500.3025";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat11()
        {
            String inputNumber = "1,6.00,500.3025";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat12()
        {
            String inputNumber = "1,6.00.500.3025";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat13()
        {
            String inputNumber = "1_6_00_500_3025";
            String expectedNumber = "16005003025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat14()
        {
            String inputNumber = "1_6_00_500.3025";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat15()
        {
            String inputNumber = "1_6_00_500.3025.01";
            String expectedNumber = "16005003025,01";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat16()
        {
            String inputNumber = "1,6.00,500.3025m";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat17()
        {
            String inputNumber = "1,6.00.500.3025m";
            String expectedNumber = "1600500,3025";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat18()
        {
            String inputNumber = "f1,600,500.3025";
            String expectedNumber = "0";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }

        [Test]
        public void checkIfControllerDecimalFormaterCanPerformFormat19()
        {
            String inputNumber = "f1.600,500.3025";
            String expectedNumber = "0";
            var result = controllerDecimalFormater.formatNumber(inputNumber) as OkObjectResult;

            ClassicAssert.NotNull(result);
            ClassicAssert.AreEqual(200, result.StatusCode);
            ClassicAssert.AreEqual(expectedNumber, ((dynamic)result.Value).EchoedMessage);
        }
    }
}
