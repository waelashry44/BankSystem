using System.ComponentModel.DataAnnotations;

namespace OpenBank.Request
{
    public class CreateBankAccountRequest
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public double InitialDeposite { get; set; }
    }
}
