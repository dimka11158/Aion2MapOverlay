using YamlDotNet.Serialization;

namespace Aion2MapOverlay.Models;

public class MarkerFileData
{
    [YamlMember(Alias = "markers")]
    public List<MarkerData> Markers { get; set; } = [];
}

public class MarkerData
{
    [YamlMember(Alias = "subtype")]
    public string Subtype { get; set; } = "";

    [YamlMember(Alias = "x")]
    public double X { get; set; }

    [YamlMember(Alias = "y")]
    public double Y { get; set; }

    [YamlMember(Alias = "name")]
    public string Name { get; set; } = "";
}

public enum Faction { Elyos, Asmodians, Abyss }
