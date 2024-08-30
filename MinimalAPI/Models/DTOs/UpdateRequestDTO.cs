namespace MinimalAPI.Models.DTOs
{
    public record UpdateRequestDTO(int Id, string Name, string Description, double price, int Quantity);
}
