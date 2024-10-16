using Microsoft.AspNetCore.Mvc;
using TextAnalyzer.models;
using TextAnalyzer.Utility;

namespace TextAnalyzer.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerStringAppearances : ControllerBase
    {
        private String messageResult;
        private StringAppearances strAppearances;

        public ControllerStringAppearances()
        {
            strAppearances = new StringAppearances();
        }

        [HttpGet("verify-word")]
        public IActionResult verifyWord(string word, string message)
        {

            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(new ControllerResponse
                {
                    EchoedMessage = "Message cannot be empty."
                });
            }
            else
            {
                messageResult = Convert.ToString(strAppearances.verify_word(word,message));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }
        }

        [HttpGet("verify-words")]
        public IActionResult verifyWords(string words, string message)
        {

            if (string.IsNullOrWhiteSpace(words) || string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(new ControllerResponse
                {
                    EchoedMessage = "Message cannot be empty."
                });
            }
            else
            {
                messageResult = Convert.ToString(strAppearances.verify_words(words, message));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }
        }

        [HttpGet("verify-letter")]
        public IActionResult verifyLetter(Char words, string message)
        {

            if ( string.IsNullOrWhiteSpace(words.ToString()) || string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(new ControllerResponse
                {
                    EchoedMessage = "Message cannot be empty."
                });
            }
            else
            {
                messageResult = Convert.ToString(strAppearances.verify_letter(words, message));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }
        }

        [HttpGet("verify-many-letters")]
        public IActionResult verifyLetters(string letters, string message)
        {
            
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest(new ControllerResponse
                {
                    EchoedMessage = "Message cannot be empty."
                });
            }
            
            if (string.IsNullOrWhiteSpace(letters))
            {
                return Ok(new ControllerResponse
                {
                    EchoedMessage = "False"  // Assume empty letters mean the result is "False"
                });
            }

            messageResult = Convert.ToString(strAppearances.verify_many_letters(letters, message));

            var response = new ControllerResponse
            {
                EchoedMessage = messageResult
            };

            return Ok(response);
        }

    }
}
