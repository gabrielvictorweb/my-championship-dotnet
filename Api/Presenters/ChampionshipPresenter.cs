namespace my_championship.Api.Presenters;

public class ChampionshipPresenter
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public IEnumerable<TeamPresenter> Teams { get; set; } = new List<TeamPresenter>();

    public class TeamPresenter
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}