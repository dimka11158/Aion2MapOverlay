using Aion2MapOverlay.Models;
using OpenCvSharp;
using System.IO;
using System.Reflection;

namespace Aion2MapOverlay;

public static class ResourceLoader
{
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();

    public static Mat LoadMapImage(Faction faction)
    {
        string resourceName = faction switch
        {
            Faction.Elyos => "Aion2MapOverlay.Resources.maps.World_L_A.jpg",
            Faction.Asmodians => "Aion2MapOverlay.Resources.maps.World_D_A.jpg",
            Faction.Abyss => "Aion2MapOverlay.Resources.maps.Abyss_Reshanta_A.jpg",
            _ => throw new ArgumentException($"Unknown faction: {faction}")
        };

        using var stream = _assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"Resource not found: {resourceName}");

        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        var bytes = memoryStream.ToArray();

        return Cv2.ImDecode(bytes, ImreadModes.Color);
    }

    public static string LoadMarkerYaml(Faction faction)
    {
        string resourceName = faction switch
        {
            Faction.Elyos => "Aion2MapOverlay.Resources.markers.World_L_A.yaml",
            Faction.Asmodians => "Aion2MapOverlay.Resources.markers.World_D_A.yaml",
            Faction.Abyss => "Aion2MapOverlay.Resources.markers.Abyss_Reshanta_A.yaml",
            _ => throw new ArgumentException($"Unknown faction: {faction}")
        };

        using var stream = _assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"Resource not found: {resourceName}");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    public static System.Drawing.Icon LoadIcon()
    {
        const string resourceName = "Aion2MapOverlay.Resources.icon.ico";

        using var stream = _assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"Resource not found: {resourceName}");

        return new System.Drawing.Icon(stream);
    }
}
