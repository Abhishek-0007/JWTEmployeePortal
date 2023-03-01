using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JWTEmployeePortal.DAL.Entities
{
    [Table("EmployeeData")]
    public class RegisterEmployee
    {
        [Key]
        [JsonIgnore]
        public int? Id { get; set; }
        [Required]
        public string  Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Byte[] Password { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public bool? isLoggedIn { get; set; }
    }
}
