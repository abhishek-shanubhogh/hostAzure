using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace hostAzure.Models
{
    public class peopleData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name / Last Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime Date { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
    }
}
