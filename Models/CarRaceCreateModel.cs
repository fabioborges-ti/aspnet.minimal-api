namespace MinimalApi.Models
{
    public record CarRaceCreateModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public int TimeLimit { get; set; }
    }
}
