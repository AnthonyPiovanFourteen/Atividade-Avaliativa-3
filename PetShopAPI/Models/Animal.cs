using System.Text.Json.Serialization;

namespace PetShopAPI.Models
{
public class Animal
{
    public int Id { get; set; }
    public required string Nome { get; set; }
    public required string Especie { get; set; }
    public string? Raca { get; set; }
    public int Idade { get; set; }
    public double Peso { get; set; }
    public int DonoId { get; set; } 
    [JsonIgnore] 
    public virtual Dono? Dono { get; set; }
}
} 