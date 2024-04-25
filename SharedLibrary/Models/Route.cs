using System.ComponentModel.DataAnnotations.Schema;
using WeRun_App.Utilities;
using SharedLibrary.Models;

namespace WeRun_App.Entities
{
    [Table("Routes")]
    public class Route
    {
        public uint RouteId { get; set; }
        public string? RouteName { get; set; }
        public string? StartPoint { get; set; }
        public string? EndPoint { get; set; }
        public double? TotalDistance { get; set; } //distance in meters, can convert with constants
        public string? MapData { get; set; }
        public double? ElevationGain { get; set; }

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
        public int UserId { get; set; }
    }
}