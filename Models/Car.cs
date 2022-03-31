﻿namespace MinimalApi.Models
{
    public record Car
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public int Speed { get; set; }
        public double MelfunctionChance { get; set; }
        public int MelfunctionsOccured { get; set; }
        public int DistanceCoverdInMiles { get; set; }
        public bool FinishedRace { get; set; }
        public int RacedForHours { get; set; }
    }
}
