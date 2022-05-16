using System.ComponentModel.DataAnnotations;

namespace OpenBank.Request
{
    public class TransferToAccountRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than zero")]
        public int SenderBankAccountId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than zero")]
        public int ReciverBankAccountId { get; set; }
        [Required]
        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than zero.")]
        public double Amount { get; set; }         
    }
}
