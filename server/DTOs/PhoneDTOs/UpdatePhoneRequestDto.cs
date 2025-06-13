using System.ComponentModel.DataAnnotations;

namespace TTMStest.Server.DTOs.PhoneDTOs
{
    public class UpdatePhoneRequestDto
    {
        [Required]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Numer telefonu musi składać się dokładnie z 9 cyfr.")]
        public string Number { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}