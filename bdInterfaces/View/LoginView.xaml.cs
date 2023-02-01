
using System.Windows;
using System.Windows.Input;
using bdInterfaces.DB;

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
        
        if (Db.login(TxtUser.Text, TxtPass.Password))
        {
            MainView main = new MainView();
            this.Close();
            main.Show();
            
        }
        else
        {
            TxtPass.Password = "";
            MessageBox.Show("Usuario y/o contraseña no válidos");
        }
        Db.cerrarConexion();
    }
    
}