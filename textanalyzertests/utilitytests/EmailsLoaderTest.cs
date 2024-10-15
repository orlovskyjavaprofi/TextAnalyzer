

using NUnit.Framework.Legacy;
using System.Collections;
using TextAnalyzer.Utility;

namespace TextAnalyzer.utilitytests
{
    public class EmailsLoaderTest
    {
        private EmailsLoader emailsLoader;

        [SetUp]
        public void Setup()
        {
            emailsLoader = new EmailsLoader();
        }

        
        [Test]
        public void checkIfStringAppearancesCanBeCreatd()
        {
            ClassicAssert.NotNull(emailsLoader);
        }

        [Test]
        public void checkIfFileLoaderLoadsPath()
        {
            String filePath = @"content\emails.txt";
            string expectedPathToFileLists = Path.Combine(AppContext.BaseDirectory, filePath);

            ClassicAssert.AreEqual(expectedPathToFileLists, emailsLoader.loadPathToFile());
        }

        [Test]
        public void checkIfFileLoaderCanLoadEmailDomains()
        {
            ArrayList testList = emailsLoader.loadEmailDomainsList();
  
            ClassicAssert.NotNull(emailsLoader.loadEmailDomainsList());
            
        }
    }
}
