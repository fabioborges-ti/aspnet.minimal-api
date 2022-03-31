namespace MinimalApi.Models
{
    public record CarCreateModel
    {
        public string TeamName { get; set; }
        public int Speed { get; set; }
        public double MelfunctionChance { get; set; }
    }
}
