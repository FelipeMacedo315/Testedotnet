using System.ComponentModel.DataAnnotations;

public class UpdateUserRequest
{   public string Nome { get; set; }

    [StringLength(500)]
    public string Email { get; set; }

    [Required]
    public DateTime Cpf { get; set; }
  

    public UpdateUserRequest()
    {
    }
}