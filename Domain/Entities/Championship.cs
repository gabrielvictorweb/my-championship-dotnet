namespace my_championship.Domain.Entities;

public class Championship
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Location { get; set; }
}
