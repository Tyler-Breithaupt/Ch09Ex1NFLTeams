namespace NFLTeams.Models
{
    public class NFLSession
    {
        private const string TeamsKey = "myteams";
        private const string CountKey = "teamcount";
        private const string ConfKey = "conf";
        private const string DivKey = "div";
        private const string NameKey = "name";

        private ISession Session { get; set; }

        public void SetName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
            {
                Session.Remove(NameKey);
            }
            else
            {
                Session.SetString(NameKey, userName);
            }
        }
        public string GetName() => Session.GetString(NameKey) ?? string.Empty;

        public NFLSession(ISession session) => this.Session = session;

        public void SetMyTeams(List<Team> teams) {
            Session.SetObject(TeamsKey, teams);
            Session.SetInt32(CountKey, teams.Count);
        }
        public List<Team> GetMyTeams() =>
            Session.GetObject<List<Team>>(TeamsKey) ?? new List<Team>();
        public int? GetMyTeamCount() => Session.GetInt32(CountKey);

        public void SetActiveConf(string activeConf) =>
            Session.SetString(ConfKey, activeConf);
        public string GetActiveConf() => 
            Session.GetString(ConfKey) ?? string.Empty;

        public void SetActiveDiv(string activeDiv) =>
            Session.SetString(DivKey, activeDiv);
        public string GetActiveDiv() => 
            Session.GetString(DivKey) ?? string.Empty;

        public void RemoveMyTeams() {
            Session.Remove(TeamsKey);
            Session.Remove(CountKey);
        }
    }
}