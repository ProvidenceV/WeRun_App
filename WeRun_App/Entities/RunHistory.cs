using System.ComponentModel.DataAnnotations.Schema;
using WeRun_App.Utilities;


namespace WeRun_App.Entities
{
    [Table("RunHistory")]
    public class RunHistory
    {
        public int? HistoryId { get; set; }
        public int? TotalRuns { get; set; }
        public double? TotalDistance { get; set; } //distance in meters, can convert with constants
        public int? TotalCalories { get; set; }
        public TimeSpan? BestTime { get; set; }
        public double? BestDistance { get; set; }

        //functions
        public double GetDistanceInKilometers(double DistanceInMeters)
        {
            return DistanceConverter.ConvertMetersToKilometers(DistanceInMeters);
        }

        public double GetDistanceInMiles(double DistanceInMeters)
        {
            return DistanceConverter.ConvertMetersToMiles(DistanceInMeters);
        }

        //relationship
        public User User { get; set; }
        public uint UserId { get; set; }

        public Route Route { get; set; }
        public uint RouteId { get; set; }


    }
}