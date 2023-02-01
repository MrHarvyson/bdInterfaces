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
    // definimos conexion
    static MySqlConnection conexion =
        new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=pocholo001;database=bdinterfaces");


    // login
    public static Boolean login(String usuario, String contrasena)
    {
        Boolean existe = false;
        try
        {
            conexion.Open();
            string consultaUser = "SELECT * FROM users WHERE User = '" + usuario + "' and Password = '" + contrasena +
                                  "'";
            MySqlCommand cmd = new MySqlCommand(consultaUser, conexion);
            MySqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                existe = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return existe;
    }

    // combobox categorias
    public static MySqlDataReader cbCategoria()
    {
        MySqlDataReader registro = null;
        try
        {
            MySqlCommand cmd = new MySqlCommand("SELECT CategoryName FROM categories", conexion);
            conexion.Open();
            registro = cmd.ExecuteReader();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return registro;
    }

    // insertar producto
    public static void insertar(String txtProducto, String txtCategoria)
    {
        try
        {
            if (!existe(txtProducto))
            {
                int id = obtenerCategoria(txtCategoria);
                String consulta = "INSERT INTO products (ProductName, CategoryID) VALUES ('" + txtProducto + "','" +
                                  id +
                                  "')";
                MySqlCommand cmd = new MySqlCommand(consulta, conexion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("PRODUCTO EXISTE");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    // obtener numero de categoria
    public static int obtenerCategoria(string categoriaName)
    {
        int id = 0;
        try
        {
            String consulta = "SELECT CategoryID FROM categories WHERE CategoryName ='" + categoriaName + "'";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            conexion.Open();
            id = (int)cmd.ExecuteScalar();
            conexion.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return id;
    }


    // borrar producto
    public static void borrar(String textoProducto)
    {
        try
        {
            string consulta = "DELETE FROM products WHERE ProductName = '" + textoProducto + "'";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            conexion.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    // modificar producto
    public static void modificar(String productoNuevo, String productoAntiguo, String categoriaName)
    {
        try
        {
            string consulta = "UPDATE products SET ProductName = '" + productoNuevo + "', CategoryID = '" +
                              obtenerCategoria(categoriaName) + "' WHERE ProductName = '" + productoAntiguo + "'";
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);
            conexion.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    // comprobar que existe producto
    public static Boolean existe(String producto)
    {
        Boolean existe = false;
        try
        {
            String consulta = "SELECT ProductName FROM products WHERE ProductName ='" + producto + "'";
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand(consulta, conexion);

            MySqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                existe = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            conexion.Close();
        }

        return existe;
    }
    
    // cerramos la conexion
    public static void cerrarConexion()
    {
        conexion.Close();
    }
}