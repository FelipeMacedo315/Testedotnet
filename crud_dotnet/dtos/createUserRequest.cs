using System.ComponentModel.DataAnnotations;

public class CreateUserRequest
{
    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [StringLength(500)]
    public string Email { get; set; }

    [Required]
    public DateTime Cpf { get; set; }

}