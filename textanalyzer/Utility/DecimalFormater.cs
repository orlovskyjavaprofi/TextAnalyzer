using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace textanalyzer.Utility
{
    public class DecimalFormater
    {
        public String formatNumber(String inputNumber)
        {
            String result = "Format conversion error";
            Console.WriteLine(inputNumber.Length);
            int counterDots = 0;
            int counterCommas = 0;
            int counterUnderscore = 0;

            if (inputNumber.Length == 9)
            {
                result = simpleFormatConversition(inputNumber);
            }

            if (inputNumber.Length == 10)
            {                
                if (inputNumber.Contains("."))
                {
                    counterDots = countDots(inputNumber);
                    //Console.WriteLine("counted dotS: " + counterDots);
                    if (counterDots == 0 || counterDots == 1)
                    {                        
                        inputNumber = inputNumber.Replace(",", "");
                        inputNumber = replaceDots(inputNumber);                        
                    }
                    else
                    {
                        //Console.WriteLine("Dots:" + counterDots);
                        string[] parts = inputNumber.Split('.');
                        inputNumber = parts[0] + parts[1] + "," + parts[2];                        
                    }
                }
            
                result = simpleFormatConversition(inputNumber);
            }

            if (inputNumber.Length == 13)
            {
                result = simpleFormatConversition(inputNumber);
            }

            if (inputNumber.Length == 14)
            {
                counterCommas = countCommas(inputNumber);
                if (counterCommas == 2)
                {
                    string[] parts = inputNumber.Split(',');
                    inputNumber = parts[0]+parts[1]+parts[2];
                    inputNumber = inputNumber.Replace(".",",");
                    result = inputNumber;
                }
                else 
                {
                    counterDots = countDots(inputNumber);
                    if (counterDots == 2)
                    {
                        string[] parts = inputNumber.Split('.');
                        inputNumber = parts[0]+ parts[1].Replace(",", "")+","+parts[2];
                        result = inputNumber;
                    }
                }
            }

            if (inputNumber.Length == 15)
            {
                if (inputNumber.Contains("f"))
                {
                    result = "0";
                }
                else
                {
                    if (inputNumber.Contains("_"))
                    {
                        counterUnderscore = countUnderScores(inputNumber);
                        if (counterUnderscore == 4)
                        {
                            inputNumber = replaceUnderScore(inputNumber);
                            result = inputNumber;
                        }
                        if (counterUnderscore == 3)
                        {
                            inputNumber = replaceUnderScore(inputNumber);
                            inputNumber = inputNumber.Replace('.', ',');
                            result = inputNumber;
                        }
                    }
                    else
                    {
                        counterDots = countDots(inputNumber);
                        if (counterDots == 3)
                        {
                            string[] parts = inputNumber.Split('.');
                            inputNumber = parts[0].Replace(",", "") + parts[1] + parts[2] + "," + parts[3];
                            result = inputNumber;
                        }
                        if (counterDots == 2)
                        {
                            string[] parts = inputNumber.Split(',');
                            inputNumber = parts[0] + parts[1].Replace(".", "") + parts[2].Replace(".", ",");
                            result = inputNumber;
                        }
                    }
                }
            }

            if (inputNumber.Length == 16)
            {
                if (inputNumber.Contains("m"))
                {
                    counterDots =countDots(inputNumber);
                    if (counterDots == 3)
                    {
                        inputNumber = inputNumber.Replace("m", "");
                        string[] parts = inputNumber.Split('.');
                        inputNumber = parts[0].Replace(",", "") + parts[1] + parts[2] + "," + parts[3];
                        result = inputNumber;
                    }
                    else
                    {
                        inputNumber = inputNumber.Replace(",", "");
                        inputNumber = inputNumber.Replace("m", "");
                        string[] parts = inputNumber.Split('.');
                        inputNumber = parts[0] + parts[1] + "," + parts[2];
                        result = inputNumber;
                    }
                }
            }

            if (inputNumber.Length == 18)
            {
                if (inputNumber.Contains("_"))
                {
                    inputNumber = replaceUnderScore(inputNumber);
                    inputNumber = inputNumber.Replace(".",",");

                    counterCommas = countCommas(inputNumber);
                    if(counterCommas == 2)
                    {
                        string[] parts = inputNumber.Split(',');
                        inputNumber = parts[0] + parts[1] + "," + parts[2];
                    }
                    result = inputNumber;
                }
            }

            return result;
        }

        private int countDots(String inputNumber)
        {
            int counter = 0;

            for (int i = 0; i < inputNumber.Length; i++)
            {
                if (inputNumber[i] == '.')
                {
                   counter++;                  
                }                
            }
            
            return counter;
        }

        private int countCommas(String inputNumber)
        {
            int counter = 0;

            for (int i = 0; i < inputNumber.Length; i++)
            {
                if (inputNumber[i] == ',')
                {
                    counter++;
                }
            }

            return counter;
        }

        private int countUnderScores(String inputNumber)
        {
            int counter = 0;

            for (int i = 0; i < inputNumber.Length; i++)
            {
                if (inputNumber[i] == '_')
                {
                    counter++;
                }
            }

            return counter;
        }

        private String simpleFormatConversition(String input)
        {
            input = input.Replace(" ", "");
            input = replaceDots(input);
            return input;
        }

        private String replaceDots(String input)
        {
            if (input.Contains("."))
            {
                input = input.Replace(".", ",");
                return input;
            }
            else
            {
                return input;
            }
        }

        private String replaceUnderScore(String input)
        {
            if (input.Contains("_"))
            {
                input = input.Replace("_", "");
                return input;
            }
            else
            {
                return input;
            }
        }

    }
}
