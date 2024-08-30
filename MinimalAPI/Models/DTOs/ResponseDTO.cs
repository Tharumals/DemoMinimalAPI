 namespace MinimalAPI.Models.DTOs
{
    public record ResponseDTO(string Name, string Description, double price, int Quantity, DateTime Date)
    {
        public double TotalPrice = price * Quantity;
    }
    
}
 