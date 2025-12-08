namespace Aion2MapOverlay.Config;

public static class OverlaySettings
{
    public const int FramesPerSecond = 2;
    public const double MinMatchConfidence = 0.5;

    public static class Markers
    {
        public const double Size = 16.0;
        public const double StrokeThickness = 2.0;
        public static readonly (byte R, byte G, byte B) MonolithColor = (255, 0, 255);
        public static readonly (byte R, byte G, byte B) HiddenCubeColor = (0, 255, 255);
        public static readonly (byte R, byte G, byte B) OdyleColor = (255, 215, 0);
        public static readonly (byte R, byte G, byte B) OrichalcumOreColor = (184, 115, 51);
        public static readonly (byte R, byte G, byte B) DiamondGemstoneColor = (185, 242, 255);
        public static readonly (byte R, byte G, byte B) YggdrasilLogColor = (34, 139, 34);
        public static readonly (byte R, byte G, byte B) SapphireGemstoneColor = (15, 82, 186);
        public static readonly (byte R, byte G, byte B) TargenaColor = (255, 127, 80);
        public static readonly (byte R, byte G, byte B) CoriolusColor = (148, 0, 211);
        public static readonly (byte R, byte G, byte B) RubyGemstoneColor = (224, 17, 95);
        public static readonly (byte R, byte G, byte B) IninaColor = (64, 224, 208);
        public static readonly (byte R, byte G, byte B) KukuruColor = (255, 165, 0);
        public static readonly (byte R, byte G, byte B) MelaColor = (50, 205, 50);
        public static readonly (byte R, byte G, byte B) AriaColor = (255, 182, 193);
        public static readonly (byte R, byte G, byte B) CypriColor = (0, 191, 255);

        public static (byte R, byte G, byte B) GetColorForSubtype(string subtype)
        {
            return subtype.ToLowerInvariant() switch
            {
                "monolithmaterial" => MonolithColor,
                "hiddencube" => HiddenCubeColor,
                "gatheringodyle" => OdyleColor,
                "gatheringorichalcumore" => OrichalcumOreColor,
                "gatheringdiamondgemstone" => DiamondGemstoneColor,
                "gatheringyggdrasillog" => YggdrasilLogColor,
                "gatheringsapphiregemstone" => SapphireGemstoneColor,
                "gatheringtargena" => TargenaColor,
                "gatheringcoriolus" => CoriolusColor,
                "gatheringrubygemstone" => RubyGemstoneColor,
                "gatheringinina" => IninaColor,
                "gatheringkukuru" => KukuruColor,
                "gatheringmela" => MelaColor,
                "gatheringaria" => AriaColor,
                "gatheringcypri" => CypriColor,
                _ => (128, 128, 128)
            };
        }
    }
}

public static class MatcherSettings
{
    public const int MaxFeatures = 4500;
    public const float RatioThreshold = 0.7f;
    public const int MinMatchCount = 10;
    public const double ReprojectionThreshold = 5.0;
    public const double EarlyExitConfidence = 0.55;
    public static readonly double[] PyramidScales = [0.5, 0.35, 0.25, 0.2, 0.15, 0.125, 0.1];

    public static class UIMask
    {
        public const double TopMaskPercent = 0.05;
        public const double RightMaskPercent = 0.034;
    }

    public static class Validation
    {
        public const double MinInlierRatio = 0.3;
        public const double MinAreaRatio = 0.01;
        public const double MaxAreaRatio = 100.0;
        public const double MaxAspectDeviation = 0.5;
        public const int CornerBoundsTolerance = 100;
    }
}
