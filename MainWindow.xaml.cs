using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;


namespace bd_embutidos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private DataTable BuscarDatos(string condicion = "1 = 1")
        {
            clsconexion cn = new clsconexion();
            DataTable dt = new DataTable();
            string query = $"Select * from tb_embutidos where {condicion}";
            cn.consultaTablaDirecta(query);
            return dt;

        }
        private DataTable BuscarDatos2(string condicion = "1 = 1")
        {
            clsconexion2 cn = new clsconexion2();
            DataTable dt = new DataTable();
            string query = $"Select * from tb_embutidos where {condicion}";
            cn.consultaTablaDirecta(query);
            return dt;

        }

        private void btnbuscar_Click(object sender, RoutedEventArgs e)
        {
            var dt = BuscarDatos();
            clsconexion cn = new clsconexion();
            gridalumnos.DataContext = cn.consultaTablaDirecta($"Select * from tb_embutidos").DefaultView;
           
        
      

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = Textboxid.Text;
            string nombre = Textboxnom.Text;
            string cant = Textboxcant.Text;
            string prec = Textboxprec.Text;
            string fecha = Textboxfech.Text;
            string sentencia = $"insert into tb_embutidos(id_embutidos,nombre,cantidad,precio,fecha) values({id},'{nombre}',{cant},{prec},'{fecha}')  ";
            clsconexion cn = new clsconexion();
            cn.EjecutaSQLDirecto(sentencia);
            BuscarDatos();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string id = txtid.Text;
            clsconexion cn = new clsconexion();
            string query = $"select * from tb_embutidos where id_embutidos={id}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count >0)
            {
                string nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = nombre;
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                int precio = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = precio.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string id = txtid.Text;
            string nombre = txtnom.Text;
            string cantidad = txtcan.Text;
            string precio = txtpre.Text;
            string fecha = txtfe.Text;
            
            string sentencia= $"update tb_embutidos set nombre ='{nombre}', cantidad={cantidad}, precio={precio}, fecha='{fecha}' where id_embutidos={id}";
            clsconexion cn = new clsconexion();
            cn.EjecutaSQLDirecto(sentencia);
            BuscarDatos();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string id = txtid.Text;
            string nombre = txtnom.Text;
            string sentencia = $"delete from tb_embutidos where id_embutidos={id}";
            clsconexion cn = new clsconexion();
            cn.EjecutaSQLDirecto(sentencia);
            BuscarDatos();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var dt = BuscarDatos2();
            clsconexion2 cn = new clsconexion2();
            gridalumnos.DataContext = cn.consultaTablaDirecta($"Select * from tb_embutidos").DefaultView;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string id = Textboxid.Text;
            string nombre = Textboxnom.Text;
            string cant = Textboxcant.Text;
            string prec = Textboxprec.Text;
            string fecha = Textboxfech.Text;
            string sentencia = $"insert into tb_embutidos(id_embutido,nombre,cantidad,precio,fecha) values({id},'{nombre}',{cant},{prec},'{fecha}')  ";
            clsconexion2 cn = new clsconexion2();
            cn.EjecutaSQLDirecto(sentencia);
            BuscarDatos2();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string id = txtid.Text;
            clsconexion2 cn = new clsconexion2();
            string query = $"select * from tb_embutidos where id_embutido={id}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                string nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = nombre;
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                int precio = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = precio.ToString();
                string fec = dt.Rows[0].Field<string>("fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
            BuscarDatos2();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string id = txtid.Text;
            string nombre = txtnom.Text;
            string sentencia = $"delete from tb_embutidos where id_embutido={id}";
            clsconexion2 cn = new clsconexion2();
            cn.EjecutaSQLDirecto(sentencia);
            BuscarDatos2();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string id = txtid.Text;
            string nombre = txtnom.Text;
            string cantidad = txtcan.Text;
            string precio = txtpre.Text;
            string fecha = txtfe.Text;

            string sentencia = $"update tb_embutidos set nombre ='{nombre}', cantidad={cantidad}, precio={precio}, fecha='{fecha}' where id_embutido={id}";
            clsconexion2 cn = new clsconexion2();
            cn.EjecutaSQLDirecto(sentencia);
            BuscarDatos2();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            string nombre = txtnom.Text;
            clsconexion cn = new clsconexion();
            string query = $"select * from tb_embutidos where Nombre='{nombre}'";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutidos");
                txtid.Text = id.ToString();
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                int precio = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = precio.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            string cantidad = txtcan.Text;
            clsconexion cn = new clsconexion();
            string query = $"select * from tb_embutidos where Cantidad={cantidad}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutidos");
                txtid.Text = id.ToString();
                string Nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = Nombre;
                int precio = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = precio.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
            BuscarDatos();
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            string Precio = txtpre.Text;
            clsconexion cn = new clsconexion();
            string query = $"select * from tb_embutidos where Precio={Precio}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutidos");
                txtid.Text = id.ToString();
                string Nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = Nombre;
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
           
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            string fecha = txtfe.Text;
            clsconexion cn = new clsconexion();
            string query = $"select * from tb_embutidos where Fecha='{fecha}'";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutidos");
                txtid.Text = id.ToString();
                string Nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = Nombre;
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                int pre = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = pre.ToString();

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            string nombre = txtnom.Text;
            clsconexion2 cn = new clsconexion2();
            string query = $"select * from tb_embutidos where Nombre='{nombre}'";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutido");
                txtid.Text = id.ToString();
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                int precio = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = precio.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            string cantidad = txtcan.Text;
            clsconexion2 cn = new clsconexion2();
            string query = $"select * from tb_embutidos where Cantidad={cantidad}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutido");
                txtid.Text = id.ToString();
                string Nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = Nombre;
                int precio = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = precio.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            string Precio = txtpre.Text;
            clsconexion2 cn = new clsconexion2();
            string query = $"select * from tb_embutidos where Precio={Precio}";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutido");
                txtid.Text = id.ToString();
                string Nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = Nombre;
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                string fec = dt.Rows[0].Field<string>("Fecha");
                txtfe.Text = fec;

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            string fecha = txtfe.Text;
            clsconexion2 cn = new clsconexion2();
            string query = $"select * from tb_embutidos where Fecha='{fecha}'";
            DataTable dt = cn.consultaTablaDirecta(query);
            if (dt.Rows.Count > 0)
            {
                int id = dt.Rows[0].Field<int>("Id_embutido");
                txtid.Text = id.ToString();
                string Nombre = dt.Rows[0].Field<string>("Nombre");
                txtnom.Text = Nombre;
                int cantidad = dt.Rows[0].Field<int>("Cantidad");
                txtcan.Text = cantidad.ToString();
                int pre = dt.Rows[0].Field<int>("Precio");
                txtpre.Text = pre.ToString();

            }
            else
            {
                txtnom.Text = "no hay informacion";
                txtcan.Text = "no hay informacion";
                txtpre.Text = "no hay informacion";
                txtfe.Text = "no hay informacion";
            }
        }
    }
}
