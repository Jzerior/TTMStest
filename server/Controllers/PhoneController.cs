using Microsoft.AspNetCore.Mvc;
using TTMStest.Server.Interfaces.IRepositories;
using TTMStest.Server.Models;

namespace TTMStest.Server.Controllers
{
    [Route("api/phone")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;

        public PhoneController(IPhoneRepository phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhones()
        {
            var phones = await _phoneRepository.GetAllPhonesAsync();
            return Ok(phones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneById(int id)
        {
            var phone = await _phoneRepository.GetPhoneByIdAsync(id);
            if (phone == null)
                return NotFound();
            return Ok(phone);
        }

        [HttpPost]
        public async Task<IActionResult> AddPhone([FromBody] Phone phone)
        {
            Console.WriteLine($"Dodawanie telefonu: Name={phone.Name}, Number={phone.Number}");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdPhone = await _phoneRepository.AddPhoneAsync(phone);
            return CreatedAtAction(nameof(GetPhoneById), new { id = createdPhone.Id }, createdPhone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePhone(int id, [FromBody] Phone phone)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedPhone = await _phoneRepository.UpdatePhoneAsync(id, phone);
            if (updatedPhone == null)
                return NotFound();

            return Ok(updatedPhone);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhone(int id)
        {
            var deletedPhone = await _phoneRepository.DeletePhoneAsync(id);
            if (deletedPhone == null)
                return NotFound();

            return NoContent();
        }
    }
}