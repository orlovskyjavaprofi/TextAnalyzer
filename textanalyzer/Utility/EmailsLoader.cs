using System.Collections;

namespace TextAnalyzer.Utility
{
    public class EmailsLoader
    {
        public String loadPathToFile()
        {
            String emailFilePath = @"content\emails.txt";
            String errorPath = "Can't find path to file!";

            string filePath = Path.Combine(AppContext.BaseDirectory, emailFilePath);
            
            if (File.Exists(filePath))
            {
               return filePath;
            }
            else
            {
                return errorPath;
            }
        }

        public ArrayList loadEmailDomainsList()
        {
            ArrayList listOfEmailDomains = new ArrayList();

            try
            {
                using (StreamReader reader = new StreamReader(loadPathToFile()))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {                        
                        string trimmedLine = line.Trim();
                        if (!string.IsNullOrEmpty(trimmedLine))
                        {
                            listOfEmailDomains.Add(trimmedLine); 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during read of file: {ex.Message}");
            }

            return listOfEmailDomains;

        }
    }
}
