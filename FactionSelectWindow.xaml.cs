using Aion2MapOverlay.Models;
using System.Windows;
using System.Windows.Input;

namespace Aion2MapOverlay;

public partial class FactionSelectWindow : Window
{
    public FactionSelectWindow()
    {
        InitializeComponent();
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
        var overlayWindow = new OverlayWindow(faction);
        overlayWindow.Show();
        Close();
    }
}
