using Aion2MapOverlay.Models;
using System.Windows;
using System.Windows.Input;

namespace Aion2MapOverlay;

public partial class FactionSelectWindow : Window
{
    public bool OverlayStarted { get; private set; }

    private readonly Faction? _currentFaction;
    private readonly MarkerFilter? _currentFilter;

    public FactionSelectWindow() : this(null, null)
    {
    }

    public FactionSelectWindow(Faction? currentFaction, MarkerFilter? currentFilter)
    {
        InitializeComponent();

        _currentFaction = currentFaction;
        _currentFilter = currentFilter;

        if (currentFilter != null)
        {
            MonolithCheckBox.IsChecked = currentFilter.ShowMonolith;
            HiddenCubeCheckBox.IsChecked = currentFilter.ShowHiddenCube;
            OdyleCheckBox.IsChecked = currentFilter.ShowOdyle;
            OrichalcumOreCheckBox.IsChecked = currentFilter.ShowOrichalcumOre;
            DiamondGemstoneCheckBox.IsChecked = currentFilter.ShowDiamondGemstone;
            YggdrasilLogCheckBox.IsChecked = currentFilter.ShowYggdrasilLog;
            SapphireGemstoneCheckBox.IsChecked = currentFilter.ShowSapphireGemstone;
            TargenaCheckBox.IsChecked = currentFilter.ShowTargena;
            CoriolusCheckBox.IsChecked = currentFilter.ShowCoriolus;
            RubyGemstoneCheckBox.IsChecked = currentFilter.ShowRubyGemstone;
            IninaCheckBox.IsChecked = currentFilter.ShowInina;
            KukuruCheckBox.IsChecked = currentFilter.ShowKukuru;
            MelaCheckBox.IsChecked = currentFilter.ShowMela;
            AriaCheckBox.IsChecked = currentFilter.ShowAria;
            CypriCheckBox.IsChecked = currentFilter.ShowCypri;
        }
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ElyosButton_Click(object sender, RoutedEventArgs e)
    {
        StartOverlay(Faction.Elyos);
    }

    private void AsmodiansButton_Click(object sender, RoutedEventArgs e)
    {
        StartOverlay(Faction.Asmodians);
    }

    private void AbyssButton_Click(object sender, RoutedEventArgs e)
    {
        StartOverlay(Faction.Abyss);
    }

    private void StartOverlay(Faction faction)
    {
        var filter = new MarkerFilter
        {
            ShowMonolith = MonolithCheckBox.IsChecked == true,
            ShowHiddenCube = HiddenCubeCheckBox.IsChecked == true,
            ShowOdyle = OdyleCheckBox.IsChecked == true,
            ShowOrichalcumOre = OrichalcumOreCheckBox.IsChecked == true,
            ShowDiamondGemstone = DiamondGemstoneCheckBox.IsChecked == true,
            ShowYggdrasilLog = YggdrasilLogCheckBox.IsChecked == true,
            ShowSapphireGemstone = SapphireGemstoneCheckBox.IsChecked == true,
            ShowTargena = TargenaCheckBox.IsChecked == true,
            ShowCoriolus = CoriolusCheckBox.IsChecked == true,
            ShowRubyGemstone = RubyGemstoneCheckBox.IsChecked == true,
            ShowInina = IninaCheckBox.IsChecked == true,
            ShowKukuru = KukuruCheckBox.IsChecked == true,
            ShowMela = MelaCheckBox.IsChecked == true,
            ShowAria = AriaCheckBox.IsChecked == true,
            ShowCypri = CypriCheckBox.IsChecked == true
        };

        if (_currentFaction != faction || !filter.Equals(_currentFilter))
        {
            var overlayWindow = new OverlayWindow(faction, filter);
            overlayWindow.Show();
            OverlayStarted = true;
        }

        Close();
    }
}
