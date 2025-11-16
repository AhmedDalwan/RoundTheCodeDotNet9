namespace RoundTheCodeDotNet9.LinqMethods
{
    public record PremierLeagueResults(string Team, ResultEnum Result, string OpposingTeam);

    public enum ResultEnum
    {
        Win,
        Lose,
        Draw
    }

    public class LinqAggregateBy
    {
        List<PremierLeagueResults> premierLeagueResults =
        [
            new("Team 1", ResultEnum.Win, "Team 2"),
            new("Team 2", ResultEnum.Lose, "Team 4"),
            new("Team 3", ResultEnum.Lose, "Team 1"),
            new("Team 4", ResultEnum.Draw, "Team 3"),
            new("Team 3", ResultEnum.Win, "Team 2"),
            new("Team 1", ResultEnum.Win, "Team 4"),
        ];

        public Dictionary<string, int> GetPoints()
        {
            var premierLeagueTeamPoints = new Dictionary<string, int>();

            var res = premierLeagueResults.AggregateBy(a =>
            a.Team,
            seed => 0,
            (seed, pls) => seed + (pls.Result is ResultEnum.Win ? 3 : (pls.Result is ResultEnum.Draw ? 1 : 0)));

            foreach (var team in res)
            {
                premierLeagueTeamPoints.Add(team.Key, team.Value);
            }

            return premierLeagueTeamPoints;
        }
    }
}