namespace marketing_api.DTOs.StockDTOs;
public class StockDto
{
    public int Id { get; set; }
    public StockProductDto Product { get; set; }
    public int Quanitty { get; set; }
}