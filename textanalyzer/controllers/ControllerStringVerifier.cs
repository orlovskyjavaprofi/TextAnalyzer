using Microsoft.AspNetCore.Mvc;
using TextAnalyzer.models;
using TextAnalyzer.Utility;

namespace TextAnalyzer.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerStringVerifier : ControllerBase
    {
        private StringVerifier strVerfier;
        private String messageResult;

        public ControllerStringVerifier()
        {
            strVerfier = new StringVerifier();
        }

        [HttpGet("count-words")]
        public IActionResult countWords(string message)
        {
            
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("Message cannot be empty.");
            }
            else
            {
                messageResult = Convert.ToString(strVerfier.count_words_in_string(message));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }
           
        }

        [HttpGet("count-letter")]
        public IActionResult countLetter(Char letter, String word)
        {

            if (letter != null && string.IsNullOrWhiteSpace(word))
            {
                return BadRequest("Message cannot be empty.");
            }
            else
            {
                messageResult = Convert.ToString(strVerfier.count_letter_in_word(letter, word));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }

        }

        [HttpGet("count-many-letters")]
        public IActionResult countManyLetters(String letters, String word)
        {

            if (string.IsNullOrWhiteSpace(letters) && string.IsNullOrWhiteSpace(word))
            {
                return BadRequest("Message cannot be empty.");
            }
            else
            {
                messageResult = Convert.ToString(strVerfier.count_many_letter_in_word(letters, word));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }

        }

        [HttpGet("check-b64code")]
        public IActionResult verifyB64Code(String b64code)
        {

            if (string.IsNullOrWhiteSpace(b64code))
            {
                return BadRequest("Message cannot be empty.");
            }
            else
            {
                messageResult = Convert.ToString(strVerfier.isBase64Str(b64code));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }

        }

        [HttpGet("validate-email")]
        public IActionResult validateEmail(String givenEmail)
        {

            if (string.IsNullOrWhiteSpace(givenEmail))
            {
                return BadRequest(new ControllerResponse
                {
                    EchoedMessage = "Message cannot be empty."
                });
            }
            else
            {
                messageResult = Convert.ToString(strVerfier.isValidEmail(givenEmail));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }

        }
    }
}
