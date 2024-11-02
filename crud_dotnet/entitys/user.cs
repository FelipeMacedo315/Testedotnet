using System.ComponentModel.DataAnnotations;

namespace crud_dotnet.entitys
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