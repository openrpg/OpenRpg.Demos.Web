namespace OpenRpg.Demos.Web.Models;

public class FixedPointData
{
    public static float[] FixedPoints = Enumerable.Range(0, 50)
        .Select(x => (float)(x*2) / 100)
        .ToArray(); 
}