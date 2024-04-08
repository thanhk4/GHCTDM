using System.ComponentModel.DataAnnotations;

namespace GHCTDM.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}
