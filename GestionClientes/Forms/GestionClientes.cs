using GestionClientes.DAO;
using GestionClientes.Forms;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionClientes
{
    public partial class GestionClientes : Form
    {
        public GestionClientes()
        {
            InitializeComponent();
        }

        private void GestionClientes_Load(object sender, EventArgs e)
        {
            actualizarLista();

        }

        private void actualizarLista()
        {
            ClienteDao dbConexion = new ClienteDao();
            List<Cliente> listaDb = dbConexion.ObtenerListadoClientes();

            listClientes.Items.Clear();
            dgvClientes.DataSource = listaDb;
            dgvClientes.Columns["Id"].Visible = false;
            dgvClientes.Columns["Estado"].Visible = false;
            dgvClientes.Columns["NombreCompleto"].Visible = false;
            //dgvClientes.

            for (int i = 0; i < listaDb.Count; i++)
            {
               Cliente cliente = listaDb[i];
               listClientes.Items.Add(cliente);
               
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Edad = Int32.Parse(txtEdad.Text);
            cliente.Email = txtEmail.Text;
            cliente.Tel = txtTel.Text;

            ClienteDao dbConexion = new ClienteDao();
            dbConexion.Guardar(cliente);

            actualizarLista();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(dgvClientes.CurrentRow.Cells["Id"].Value.ToString());
            ClienteDao dbConexion = new ClienteDao();
            dbConexion.Eliminar(id);
            MessageBox.Show("El cliente se elimino con exito");

            actualizarLista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarLista();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            int id = Int32.Parse(dgvClientes.CurrentRow.Cells["Id"].Value.ToString());
            EditarCliente formEditar = new EditarCliente(id);
            formEditar.ShowDialog();
            actualizarLista();
        }
    }
}
