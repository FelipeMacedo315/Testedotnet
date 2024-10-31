using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public User()
        {
        }
    }
}