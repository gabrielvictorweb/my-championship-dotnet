namespace my_championship.Application.DTOs;

public class CreateChampionshipDto
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string[] TeamNames { get; set; } = Array.Empty<string>();
}
