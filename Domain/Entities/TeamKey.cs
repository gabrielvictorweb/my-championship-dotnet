namespace my_championship.Domain.Entities;

public class TeamKey
{
    public Guid Id { get; set; }
    public Guid ChampionshipId { get; set; }
    public Championship Championship { get; set; } = null!;
    public Guid TeamId { get; set; }
    public Team Team { get; set; } = null!;
    public required string Key { get; set; }
}