using Microsoft.AspNetCore.Mvc;
using PhoneNumberValidator.Dtos;
using PhoneNumberValidator.Helpers;

namespace PhoneNumberValidator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhoneNumberController : ControllerBase
    {
        private const int InternalServerErrorStatusCode = 501;

        private readonly ILogger<PhoneNumberController> _logger;

        public PhoneNumberController(ILogger<PhoneNumberController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<string> Validate(ValidateRequestDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string? phoneNumber;
            try
            {
                try
                {
                    var manager = new PhonesNumberParsersManager(dto.Prefix);
                    phoneNumber = manager.Parse(dto.RegionCode, dto.PhoneNumber);
                }
                catch(ArgumentException)
                {
                    return BadRequest("Invalid phone number.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(InternalServerErrorStatusCode, ex.Message);
            }

            return Ok(phoneNumber);
        }
    }
}