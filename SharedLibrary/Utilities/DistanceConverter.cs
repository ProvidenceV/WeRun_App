namespace WeRun_App.Utilities
{
    public static class DistanceConverter
    {
        public static double ConvertMetersToKilometers(double meters)
        {
            return meters * 0.001;
        }

        public static double ConvertMetersToMiles(double meters)
        {
            return meters * 0.000621371;
        }

        // Optionally, include methods for other conversions as needed
        public static double ConvertKilometersToMiles(double kilometers)
        {
            return kilometers * 0.621371;
        }

        public static double ConvertMilesToKilometers(double miles)
        {
            return miles / 0.621371;
        }
    }
}