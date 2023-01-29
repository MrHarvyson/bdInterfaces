
using System.Windows;
using System.Windows.Input;
namespace bdInterfaces.View;

public partial class LoginView : Window
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void LoginView_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed) DragMove();
    }

    private void BtnMinimizar_OnClick(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void BtnCerrar_OnClick(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BtnLogin_OnClick(object sender, RoutedEventArgs e)
    {
        MainView main = new MainView();
        this.Close();
        main.Show();
        /*
        if (Db.login(TxtUser.Text, TxtPass.ToString()))
        {
            MainView main = new MainView();
            this.Close();
            main.Show();
        }
        else
        {
            MessageBox.Show("Usuario y/o contraseña no válidos");
        }
        */
    }
    
}