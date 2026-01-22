namespace my_championship.Domain.Entities;

public class Team
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public Guid ChampionshipId { get; set; }
    public Championship Championship { get; set; } = null!;
}