using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using bdInterfaces.DB;
using MySql.Data.MySqlClient;

namespace bdInterfaces.Pages;

public partial class Crud : Page
{
    static MySqlConnection conexion =
        new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=pocholo001;database=bdinterfaces");

    // para sincronizar tablas productos y categorias
    public Visual GetDescendantByType(Visual element, Type type)
    {
        if (element == null) return null;
        if (element.GetType() == type) return element;
        Visual foundElement = null;
        if (element is FrameworkElement)
        {
            (element as FrameworkElement).ApplyTemplate();
        }

        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
        {
            Visual visual = VisualTreeHelper.GetChild(element, i) as Visual;
            foundElement = GetDescendantByType(visual, type);
            if (foundElement != null)
                break;
        }

        return foundElement;
    }

    private void lbx1_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        ScrollViewer _listboxScrollViewer1 = GetDescendantByType(list1, typeof(ScrollViewer)) as ScrollViewer;
        ScrollViewer _listboxScrollViewer2 = GetDescendantByType(list2, typeof(ScrollViewer)) as ScrollViewer;
        _listboxScrollViewer2.ScrollToVerticalOffset(_listboxScrollViewer1.VerticalOffset);
    }

    private void lbx2_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
        ScrollViewer _listboxScrollViewer1 = GetDescendantByType(list2, typeof(ScrollViewer)) as ScrollViewer;
        ScrollViewer _listboxScrollViewer2 = GetDescendantByType(list1, typeof(ScrollViewer)) as ScrollViewer;
        _listboxScrollViewer2.ScrollToVerticalOffset(_listboxScrollViewer1.VerticalOffset);
    }

    public Crud()
    {
        InitializeComponent();
        cargarComboBox();
        mostrarLista1();
        mostrarLista2();
        AgregarRbt.Visibility = Visibility.Visible;
        ModificarRbt.Visibility = Visibility.Hidden;
        BorrarRbt.Visibility = Visibility.Hidden;

        list1.SetValue(
            ScrollViewer.VerticalScrollBarVisibilityProperty,
            ScrollBarVisibility.Disabled);
        list2.SetValue(
            ScrollViewer.VerticalScrollBarVisibilityProperty,
            ScrollBarVisibility.Disabled);
    }

    private void mostrarLista1()
    {
        string consulta = "SELECT CONCAT(products.ProductName) as INFO FROM products, " +
                          "categories WHERE products.CategoryID = categories.CategoryID ORDER BY ProductID;";
        MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

        using (adaptador)
        {
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            list1.DisplayMemberPath = "INFO";
            list1.SelectedValuePath = "ProductName";
            list1.ItemsSource = tabla.DefaultView;
        }
    }

    private void mostrarLista2()
    {
        string consulta = "SELECT CONCAT(categories.CategoryName) as INFO FROM products, " +
                          "categories WHERE products.CategoryID = categories.CategoryID ORDER BY ProductID;";
        MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

        using (adaptador)
        {
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            list2.DisplayMemberPath = "INFO";
            list2.SelectedValuePath = "ProductName";
            list2.ItemsSource = tabla.DefaultView;
        }
    }

    // visualizacion de submenus
    private void RbtAgregar_OnClick(object sender, RoutedEventArgs e)
    {
        AgregarRbt.Visibility = Visibility.Visible;
        ModificarRbt.Visibility = Visibility.Hidden;
        BorrarRbt.Visibility = Visibility.Hidden;
    }

    private void RbtModificar_OnClick(object sender, RoutedEventArgs e)
    {
        AgregarRbt.Visibility = Visibility.Hidden;
        ModificarRbt.Visibility = Visibility.Visible;
        BorrarRbt.Visibility = Visibility.Hidden;
    }

    private void RbtBorrar_OnClick(object sender, RoutedEventArgs e)
    {
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
        if (TxtProducto.Text.Equals("") || CbCategoriaAgregar.SelectedItem == null)
        {
            MessageBox.Show("RELLENAR CAMPOS");
        }
        else
        {
            Db.insertar(TxtProducto.Text, CbCategoriaAgregar.SelectedValue.ToString());
            TxtProducto.Text = "";
            CbCategoriaAgregar.SelectedItem = null;

            mostrarLista1();
            mostrarLista2();
        }

        Db.cerrarConexion();
    }


    private void BtnModificar_OnClick(object sender, RoutedEventArgs e)
    {
        if (TxtProductoNuevo.Text.Equals("") || TxtProductoAntiguo.Text.Equals("") ||
            CbCategoriaModificar.SelectedItem == null)
        {
            MessageBox.Show("RELLENAR CAMPOS");
        }
        else
        {
            if (!Db.existe(TxtProductoNuevo.Text) && Db.existe(TxtProductoAntiguo.Text))
            {
                Db.modificar(TxtProductoNuevo.Text, TxtProductoAntiguo.Text,
                    CbCategoriaModificar.SelectedValue.ToString());
                Db.cerrarConexion();
                mostrarLista1();
                mostrarLista2();
            }
            else if (Db.existe(TxtProductoNuevo.Text))
            {
                MessageBox.Show("NOMBRE PRODUCTO NUEVO EXISTE");
                TxtProductoNuevo.Text = "";
            }
            else if (!Db.existe(TxtProductoAntiguo.Text))
            {
                MessageBox.Show("PRODUCTO ANTIGUO NO EXISTE");
                TxtProductoAntiguo.Text = "";
            }
        }
    }

    private void BtnBorrar_OnClick(object sender, RoutedEventArgs e)
    {
        if (Db.existe(TxtProductoBorrar.Text))
        {
            Db.borrar(TxtProductoBorrar.Text);
            TxtProductoBorrar.Text = "";
            mostrarLista1();
            mostrarLista2();
        }
        else
        {
            MessageBox.Show("PRODUCTO NO EXISTE");
            TxtProductoBorrar.Text = "";
        }

        Db.cerrarConexion();
    }
}