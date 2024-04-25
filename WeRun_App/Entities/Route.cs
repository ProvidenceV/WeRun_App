using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WeRun_App.Utilities;

namespace WeRun_App.Entities
{
    [Table("Routes")]
    public class Route
    {
        public uint RouteId { get; set; }
        public uint UserId { get; set; }
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
    }
}