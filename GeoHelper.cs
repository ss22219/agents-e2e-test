using System;

public static class GeoHelper
{
    public static double Distance(double lat1, double lon1, double lat2, double lon2)
    {
        const double R = 6371;
        double dLat = (lat2 - lat1) * Math.PI / 180;
        double dLon = (lon2 - lon1) * Math.PI / 180;
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(lat1 * Math.PI / 180) * Math.Cos(lat2 * Math.PI / 180) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        return R * c;
    }

    public static (double lat, double lon) MidPoint(double lat1, double lon1, double lat2, double lon2)
    {
        double dLon = (lon2 - lon1) * Math.PI / 180;
        double lat1Rad = lat1 * Math.PI / 180;
        double lat2Rad = lat2 * Math.PI / 180;
        double lon1Rad = lon1 * Math.PI / 180;
        double bx = Math.Cos(lat2Rad) * Math.Cos(dLon);
        double by = Math.Cos(lat2Rad) * Math.Sin(dLon);
        double lat3 = Math.Atan2(Math.Sin(lat1Rad) + Math.Sin(lat2Rad),
                                  Math.Sqrt((Math.Cos(lat1Rad) + bx) * (Math.Cos(lat1Rad) + bx) + by * by));
        double lon3 = lon1Rad + Math.Atan2(by, Math.Cos(lat1Rad) + bx);
        return (lat3 * 180 / Math.PI, lon3 * 180 / Math.PI);
    }
}
