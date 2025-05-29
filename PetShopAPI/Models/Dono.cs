using System.Collections.Generic;

namespace PetShopAPI.Models
{
    public class Dono
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public string? CPF { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public virtual ICollection<Animal> Animais { get; set; } = new List<Animal>();
}
} 