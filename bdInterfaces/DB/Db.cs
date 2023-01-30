using System;
using System.Data;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using bdInterfaces.Pages;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using TextBox = System.Windows.Forms.TextBox;

namespace bdInterfaces.DB;

public class Db
{
    static MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=pocholo001;database=bdinterfaces");
   
    
    // login
    public static Boolean login(String usuario, String contrasena)
    {
        Boolean existe = false;
        
        conexion.Open();
        string consultaUser = "SELECT * FROM users WHERE User = @vusuario";
        MySqlCommand cmd = new MySqlCommand(consultaUser, conexion);
        cmd.Parameters.AddWithValue("@vusuario", usuario);
        cmd.Parameters.AddWithValue("@contrasenia", contrasena);

        MySqlDataReader lector = cmd.ExecuteReader();
        
        if (lector.Read())
        {
            existe = true;
        }
        conexion.Close();
        return existe;
    }
    
    // combobox categorias
    public static MySqlDataReader cbCategoria()
    {
        MySqlCommand cmd = new MySqlCommand("SELECT CategoryName FROM categories",conexion);
        conexion.Open();
        MySqlDataReader registro = cmd.ExecuteReader();
        return registro;
    }
    
    // insertar producto
    public static void insertar(String txtProducto, String txtCategoria) {
        int id = obtenerCategoria(txtCategoria);
        String consulta = "INSERT INTO products (ProductName, CategoryID) VALUES ('" + txtProducto + "','" +
                          id + "')";
        MySqlCommand cmd = new MySqlCommand(consulta, conexion);
        conexion.Open();
        cmd.ExecuteNonQuery();
        conexion.Close();
    }

    // obtener nombre categoria del id
    public static int obtenerCategoria(string categoriaName)
    {
        String consulta = "SELECT CategoryID FROM categories WHERE CategoryName ='" + categoriaName +"'";
        MySqlCommand cmd = new MySqlCommand(consulta, conexion);
        conexion.Open();
        int id = (int)cmd.ExecuteScalar();
        conexion.Close();
        return id;
    }
    
    public static void cerrarConexion()
    {
        conexion.Close();
    }

    public static void borrar(String textoProducto)
    {
        string consulta = "DELETE FROM products WHERE ProductName = '" + textoProducto + "'";
        MySqlCommand cmd = new MySqlCommand(consulta, conexion);
        conexion.Open();
        cmd.ExecuteNonQuery();
    }

    public static void modificar(String productoNuevo, String productoAntiguo, String categoriaName)
    {
        string consulta = "UPDATE products SET ProductName = '" + productoNuevo + "', CategoryID = '" + obtenerCategoria(categoriaName) + "' WHERE ProductName = '" + productoAntiguo + "'";
        MySqlCommand cmd = new MySqlCommand(consulta, conexion);
        conexion.Open();
        cmd.ExecuteNonQuery();
    }
    
    
    
    
}