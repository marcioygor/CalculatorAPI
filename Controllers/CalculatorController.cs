using Microsoft.AspNetCore.Mvc;

namespace Rest1.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{SumfirstNumber}/{SumsecondNumber}")]
    public IActionResult Sum(string SumfirstNumber, string SumsecondNumber)
    {
        if (IsNumeric(SumfirstNumber) && IsNumeric(SumsecondNumber))
        {
            var sum = ConvertToDecimal(SumfirstNumber) + ConvertToDecimal(SumsecondNumber);
            return Ok(sum.ToString());
        }

        return BadRequest("Entrada inválida");
    }

    [HttpGet("multiplication/{multfirstNumber}/{multsecondNumber}")]
    public IActionResult Multiplication(string multfirstNumber, string multsecondNumber)
    {
        if (IsNumeric(multfirstNumber) && IsNumeric(multsecondNumber))
        {

            var mult = ConvertToDecimal(multfirstNumber) * ConvertToDecimal(multsecondNumber);
            return Ok(mult.ToString());
        }

        return BadRequest("Entrada inválida");
    }

    [HttpGet("subtraction/{subfirstNumber}/{subsecondNumber}")]
    public IActionResult Subtraction(string subfirstNumber, string subsecondNumber)
    {
        if (IsNumeric(subfirstNumber) && IsNumeric(subsecondNumber))
        {

            var sub = ConvertToDecimal(subfirstNumber) - ConvertToDecimal(subsecondNumber);
            return Ok(sub.ToString());
        }

        return BadRequest("Entrada inválida");
    }

    [HttpGet("division/{divfirstNumber}/{divsecondNumber}")]
    public IActionResult Division(string divfirstNumber, string divsecondNumber)
    {
        if (IsNumeric(divfirstNumber) && IsNumeric(divsecondNumber))
        {
            var div = ConvertToDecimal(divfirstNumber) / ConvertToDecimal(divsecondNumber);
            return Ok(div.ToString());
        }

        return BadRequest("Entrada inválida");
    }


    [HttpGet("Sqrt/{Number}")]
    public IActionResult Sroot(string Number)
    {
        double doubleValue=0;

        if (IsNumeric(Number) &&(double.TryParse(Number, out doubleValue)))
        {                  
            return Ok(Math.Sqrt(doubleValue).ToString());           
        }

        return BadRequest("Entrada inválida");
    }
    private bool IsNumeric(string strNumber)
    {
        double number;
        bool isNumber = double.TryParse(strNumber, System.Globalization.NumberStyles.Any,
        System.Globalization.NumberFormatInfo.InvariantInfo, out number);

        return isNumber;
    }

    private decimal ConvertToDecimal(string strNumber)
    {

        decimal decimalValue;

        if (decimal.TryParse(strNumber, out decimalValue))
        {

            return decimalValue;
        }

        return 0;
    }
}
