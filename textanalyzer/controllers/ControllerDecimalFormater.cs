using Microsoft.AspNetCore.Mvc;
using textanalyzer.Utility;
using TextAnalyzer.models;

namespace TextAnalyzer.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ControllerDecimalFormater : ControllerBase
    {
        private DecimalFormater decimalFormater;
        private String messageResult;

        public ControllerDecimalFormater(){
            decimalFormater = new DecimalFormater();
        }

        [HttpGet("format-number")]
        public IActionResult formatNumber(string inputNumber)
        {

            if (string.IsNullOrWhiteSpace(inputNumber))
            {
                return BadRequest(new ControllerResponse
                {
                    EchoedMessage = "Number cannot be empty."
                });
            }
            else
            {
                messageResult = Convert.ToString(decimalFormater.formatNumber(inputNumber));
                var response = new ControllerResponse
                {
                    EchoedMessage = messageResult
                };

                return Ok(response);
            }
        }
    }
}
