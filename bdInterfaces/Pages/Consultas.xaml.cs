using System.Data;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace bdInterfaces.Pages;

public partial class Consultas : Page
{
    static MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=pocholo001;database=bdinterfaces");

    public Consultas()
    {
        InitializeComponent();
        mostrarLista1();
        mostrarLista2();
    }
    
    private void mostrarLista1(){
      
        string consulta = "SELECT CONCAT(ProductName, '   /   ', categories.CategoryName) AS INFO FROM products, categories WHERE products.CategoryID = categories.CategoryID ORDER BY UnitsOnOrder DESC LIMIT 5;";
        MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
        
        using (adaptador)
        {
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            lista1.DisplayMemberPath = "INFO";
            lista1.SelectedValuePath = "ProductName";
            lista1.ItemsSource = tabla.DefaultView;
        }
    }

    private void mostrarLista2()
    {
        string noStock = "SELECT CONCAT(ProductName, '   /   ', categories.CategoryName) AS INFO FROM products, categories WHERE products.CategoryID = categories.CategoryID AND UnitsInStock = 0;";
        MySqlDataAdapter adaptador = new MySqlDataAdapter(noStock, conexion);

        
        using (adaptador)
        {
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            lista2.DisplayMemberPath = "INFO";
            lista2.SelectedValuePath = "ProductName";
            lista2.ItemsSource = tabla.DefaultView;
        }
    }
}