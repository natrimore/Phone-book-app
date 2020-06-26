using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Api.Models
{
    public class CreatePhoneDto
    {
        public int Id { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }

    }
}
