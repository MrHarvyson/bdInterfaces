using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using bdInterfaces.Pages;

namespace bdInterfaces.View;

public partial class MainView : Window
{
    public MainView()
    {
        InitializeComponent();
        // para que salga la barra de menu de abajo y no la tape al maximizar pantalla
    }

    private void MainView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }

    private void Volver_OnClick(object sender, RoutedEventArgs e)
    {
        LoginView main = new LoginView();
        this.Close();
        main.Show();
    }

    private void BtnCerrar_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BtnMinimizar_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }


    private void RbtInicio_OnClick(object sender, RoutedEventArgs e)
    {
        Menus.Content = new Inicio();
    }

    private void RbtCrud_OnClick(object sender, RoutedEventArgs e)
    {
        Menus.Content = new Crud();
    }

    private void RbtConsulta_OnClick(object sender, RoutedEventArgs e)
    {
        Menus.Content = new Consultas();
    }

    private void RbtAcercaDe_OnClick(object sender, RoutedEventArgs e)
    {
        Menus.Content = new AcercaDe();
    }
}