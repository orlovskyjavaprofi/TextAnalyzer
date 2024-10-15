

using NUnit.Framework.Legacy;
using textanalyzer.Utility;


namespace TextAnalyzer.utilitytests
{
    public class DecimalFormaterTest
    {
        private DecimalFormater decimalFormater;

        [SetUp]
        public void Setup()
        {
            decimalFormater = new DecimalFormater();
        }

        [Test]
        public void checkIfDecimalFormaterCanBeCreated()
        {
            ClassicAssert.NotNull(decimalFormater);
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat1()
        {
            String inputFormat = "1500,3025";
            String expectedFormat = "1500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }


        [Test]
        public void checkIfDecimalFormaterCanPerformFormat2()
        {
            String inputFormat = "1500.3025";
            String expectedFormat = "1500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat3()
        {
            String inputFormat = "1500, 3025";
            String expectedFormat = "1500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat4()
        {
            String inputFormat = "1500. 3025";
            String expectedFormat = "1500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat5()
        {
            String inputFormat = "1500,00302500";
            String expectedFormat = "1500,00302500";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat6()
        {
            String inputFormat = "1500.00302500";
            String expectedFormat = "1500,00302500";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat7()
        {
            String inputFormat = "1,500.3025";
            String expectedFormat = "1500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat8()
        {
            String inputFormat = "1.500.3025";
            String expectedFormat = "1500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat9()
        {
            String inputFormat = "1,600,500.3025";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat10()
        {
            String inputFormat = "1.600,500.3025";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat11()
        {
            String inputFormat = "1,6.00,500.3025";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat12()
        {
            String inputFormat = "1,6.00.500.3025";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat13()
        {
            String inputFormat = "1_6_00_500_3025";
            String expectedFormat = "16005003025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat14()
        {
            String inputFormat = "1_6_00_500.3025";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat15()
        {
            String inputFormat = "1_6_00_500_3025.01";
            String expectedFormat = "16005003025,01";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat16()
        {
            String inputFormat = "1_6_00_500.3025.01";
            String expectedFormat = "16005003025,01";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat17()
        {
            String inputFormat = "1,6.00,500.3025m";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat18()
        {
            String inputFormat = "1,6.00.500.3025m";
            String expectedFormat = "1600500,3025";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat19()
        {
            String inputFormat = "f1,600,500.3025";
            String expectedFormat = "0";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }

        [Test]
        public void checkIfDecimalFormaterCanPerformFormat20()
        {
            String inputFormat = "f1.600,500.3025";
            String expectedFormat = "0";

            ClassicAssert.AreEqual(expectedFormat, decimalFormater.formatNumber(inputFormat));
        }
    }
}
