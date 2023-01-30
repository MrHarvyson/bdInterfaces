using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using bdInterfaces.DB;
using MySql.Data.MySqlClient;

namespace bdInterfaces.Pages;

public partial class Crud : Page
{
    static MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=pocholo001;database=bdinterfaces");

    public Crud()
    {
        InitializeComponent();
        cargarComboBox();
        mostrarLista();
        AgregarRbt.Visibility = Visibility.Visible;
        ModificarRbt.Visibility = Visibility.Hidden;
        BorrarRbt.Visibility = Visibility.Hidden;
        
        list.SetValue(
            ScrollViewer.VerticalScrollBarVisibilityProperty,
            ScrollBarVisibility.Disabled);
            
    }

    private void mostrarLista(){
      
        string consulta ="SELECT CONCAT(products.ProductName, '  ', categories.CategoryName) as INFO FROM products, " +
                         "categories WHERE products.CategoryID = categories.CategoryID ORDER BY ProductID;";
        MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
        
        using (adaptador)
        {
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            list.DisplayMemberPath = "INFO";
            list.SelectedValuePath = "ProductName";
            list.ItemsSource = tabla.DefaultView;
        }
    }


    private void RbtAgregar_OnClick(object sender, RoutedEventArgs e)
    {
        //SubMenus.Content = new Agregar();
        AgregarRbt.Visibility = Visibility.Visible;
        ModificarRbt.Visibility = Visibility.Hidden;
        BorrarRbt.Visibility = Visibility.Hidden;
        
    }

    private void RbtModificar_OnClick(object sender, RoutedEventArgs e)
    {
        //SubMenus.Content = new Modificar();
        AgregarRbt.Visibility = Visibility.Hidden;
        ModificarRbt.Visibility = Visibility.Visible;
        BorrarRbt.Visibility = Visibility.Hidden;
    }

    private void RbtBorrar_OnClick(object sender, RoutedEventArgs e)
    {
        //SubMenus.Content = new Borrar();
        AgregarRbt.Visibility = Visibility.Hidden;
        ModificarRbt.Visibility = Visibility.Hidden;
        BorrarRbt.Visibility = Visibility.Visible;
    }
    
    public void cargarComboBox()
    {
        // cargamos el combobox
        MySqlDataReader registro = Db.cbCategoria();
        while (registro.Read())
        {
            
            CbCategoriaAgregar.Items.Add(registro["CategoryName"].ToString());
            CbCategoriaModificar.Items.Add(registro["CategoryName"].ToString());
        }
        Db.cerrarConexion();
    }

    private void BtnAgregarPro_OnClick(object sender, RoutedEventArgs e)
    {
        Db.insertar(TxtProducto.Text,CbCategoriaAgregar.SelectedValue.ToString());
        Db.cerrarConexion();
        mostrarLista();
    }


    private void BtnModificar_OnClick(object sender, RoutedEventArgs e)
    {
        Db.modificar(TxtProductoNuevo.Text,TxtProductoAntiguo.Text,CbCategoriaModificar.SelectedValue.ToString());
        Db.cerrarConexion();
        mostrarLista();
    }

    private void BtnBorrar_OnClick(object sender, RoutedEventArgs e)
    {
        Db.borrar(TxtProductoBorrar.Text);
        Db.cerrarConexion();
        mostrarLista();
    }
}