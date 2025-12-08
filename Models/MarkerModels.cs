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

public class MarkerFilter : IEquatable<MarkerFilter>
{
    public bool ShowMonolith { get; set; } = true;
    public bool ShowHiddenCube { get; set; } = true;
    public bool ShowOdyle { get; set; }
    public bool ShowOrichalcumOre { get; set; }
    public bool ShowDiamondGemstone { get; set; }
    public bool ShowYggdrasilLog { get; set; }
    public bool ShowSapphireGemstone { get; set; }
    public bool ShowTargena { get; set; }
    public bool ShowCoriolus { get; set; }
    public bool ShowRubyGemstone { get; set; }
    public bool ShowInina { get; set; }
    public bool ShowKukuru { get; set; }
    public bool ShowMela { get; set; }
    public bool ShowAria { get; set; }
    public bool ShowCypri { get; set; }

    public bool Equals(MarkerFilter? other)
    {
        if (other is null) return false;
        return ShowMonolith == other.ShowMonolith &&
               ShowHiddenCube == other.ShowHiddenCube &&
               ShowOdyle == other.ShowOdyle &&
               ShowOrichalcumOre == other.ShowOrichalcumOre &&
               ShowDiamondGemstone == other.ShowDiamondGemstone &&
               ShowYggdrasilLog == other.ShowYggdrasilLog &&
               ShowSapphireGemstone == other.ShowSapphireGemstone &&
               ShowTargena == other.ShowTargena &&
               ShowCoriolus == other.ShowCoriolus &&
               ShowRubyGemstone == other.ShowRubyGemstone &&
               ShowInina == other.ShowInina &&
               ShowKukuru == other.ShowKukuru &&
               ShowMela == other.ShowMela &&
               ShowAria == other.ShowAria &&
               ShowCypri == other.ShowCypri;
    }

    public override bool Equals(object? obj) => Equals(obj as MarkerFilter);

    public override int GetHashCode() => HashCode.Combine(
        HashCode.Combine(ShowMonolith, ShowHiddenCube, ShowOdyle, ShowOrichalcumOre),
        HashCode.Combine(ShowDiamondGemstone, ShowYggdrasilLog, ShowSapphireGemstone, ShowTargena),
        HashCode.Combine(ShowCoriolus, ShowRubyGemstone, ShowInina, ShowKukuru),
        HashCode.Combine(ShowMela, ShowAria, ShowCypri));
}
