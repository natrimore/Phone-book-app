using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Api.Models
{
    public class UpdatePhoneDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
    }
}
