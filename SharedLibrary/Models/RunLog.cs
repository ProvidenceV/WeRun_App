using System.ComponentModel.DataAnnotations.Schema;
using WeRun_App.Utilities;
using SharedLibrary.Models;

namespace WeRun_App.Entities
{
    [Table("RunLogs")]
    public class RunLog
    {
        public int RunId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? Distance { get; set; } //distance in meters, can convert with constants
        public int? CaloriesBurned { get; set; }

        //functions
        public double GetDistanceInKilometers(double DistanceInMeters)
        {
            return DistanceConverter.ConvertMetersToKilometers(DistanceInMeters);
        }

        public double GetDistanceInMiles(double DistanceInMeters)
        {
            return DistanceConverter.ConvertMetersToMiles(DistanceInMeters);
        }

        // relationship
        public User User { get; set; }
        public uint? UserId { get; set; }

        public Route Route { get; set; }
        public uint? RouteId { get; set; }
    }
}