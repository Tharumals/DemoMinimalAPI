namespace MinimalAPI.Models.DTOs
{
    public record AddRequestDTO(string Name, string Description, double price, int Quantity);
}
