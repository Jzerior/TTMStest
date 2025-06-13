using System.ComponentModel.DataAnnotations;

namespace TTMStest.Server.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression(@"^\d{9}$", ErrorMessage = "Numer telefonu musi składać się dokładnie z 9 cyfr.")]
        public string Number { get; set; }

        [MaxLength(15)]
        public string Name { get; set; }
    }
}