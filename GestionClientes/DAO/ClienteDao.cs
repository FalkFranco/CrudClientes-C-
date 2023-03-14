using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionClientes.DAO
{
    internal class ClienteDao
    {

        public MySqlConnection Conectar()
        {
            string server = "localhost";
            string user = "root";
            string password = "";
            string db = "gestionclientes";

            string cadenaConexion = "Database=" + db + "; Data Source=" + server + "; User Id=" + user + "; Password=" + password + "";

            MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);
            conexionDb.Open();

            return conexionDb;
        }

        public List<Cliente> ObtenerListadoClientes()
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM clientes WHERE estado = 1";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();


            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = Int32.Parse(lectura.GetString("id"));
                cliente.Nombre = lectura.GetString("nombre");
                cliente.Apellido = lectura.GetString("apellido");
                cliente.Edad = Int32.Parse(lectura.GetString("edad"));
                cliente.Email = lectura.GetString("email");
                cliente.Tel = lectura.GetString("telefono");
                cliente.Estado = lectura.GetBoolean("estado");

                lista.Add(cliente);
            }
            comando.Connection.Close(); // Cierra la coneccion a la base de datos

            return lista;

        }

        public void Guardar(Cliente cliente)
        {
            string consulta = "INSERT INTO `clientes` ( `nombre`, `apellido`, `edad`, `email`, `telefono`) VALUES ( '"+ cliente.Nombre + "', '"+ cliente.Apellido + "', '"+ cliente.Edad + "', '"+ cliente.Email + "', '"+ cliente.Tel +"');";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close(); // Cierra la coneccion a la base de datos
        }

        public void Eliminar(int id)
        {
            string consulta = "UPDATE `clientes` SET `estado` = '0' WHERE `clientes`.`id` = "+ id +";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close(); // Cierra la coneccion a la base de datos
        }

        public void Actualizar(Cliente cliente)
        {
            int estado;
            if(cliente.Estado = Boolean.Parse("True"))
            {
                estado = 1;
            }
            else
            {
                estado = 0;
            }

            string consulta = "UPDATE `clientes` SET `nombre` = '" + cliente.Nombre + "', `apellido` = '" + cliente.Apellido + "', `edad` = '" + cliente.Edad + "', `email` = '" + cliente.Email + "', `telefono` = '" + cliente.Tel + "', `estado` = '" + estado + "' WHERE `clientes`.`id` = "+ cliente.Id +";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close(); // Cierra la coneccion a la base de datos
        }

        public List<Cliente> Buscar(int id)
        {
            List<Cliente> lista = new List<Cliente>();

            string consulta = "SELECT * FROM clientes WHERE id = "+ id +" ";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();


            while (lectura.Read())
            {
                Cliente cliente = new Cliente();
                cliente.Id = Int32.Parse(lectura.GetString("id"));
                cliente.Nombre = lectura.GetString("nombre");
                cliente.Apellido = lectura.GetString("apellido");
                cliente.Edad = Int32.Parse(lectura.GetString("edad"));
                cliente.Email = lectura.GetString("email");
                cliente.Tel = lectura.GetString("telefono");
                cliente.Estado = lectura.GetBoolean("estado");

                lista.Add(cliente);
            }
            comando.Connection.Close(); // Cierra la coneccion a la base de datos

            return lista;
        }
    }
}
