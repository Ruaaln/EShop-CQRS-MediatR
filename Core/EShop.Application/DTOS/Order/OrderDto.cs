namespace EShop.Application.DTOs.Order;

public class OrderDto
{
    public int Id { get; set; }
    public string? OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? OrderNote { get; set; }
    public double? Total { get; set; }
    public int CustomerId { get; set; }
    public string? CustomerFullName { get; set; }
}