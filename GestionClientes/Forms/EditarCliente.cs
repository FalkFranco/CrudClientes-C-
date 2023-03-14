using GestionClientes.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionClientes.Forms
{
    public partial class EditarCliente : Form
    {
        public EditarCliente(int id)
        {
            
            InitializeComponent();
            CargarFormulario(id);
            getId(id);


        }
        private int id;
        private void getId(int idCliente)
        {
            id = idCliente;
        }

        private void EditarCliente_Load(object sender, EventArgs e)
        {
            
        }

        private void CargarFormulario(int id)
        {
            ClienteDao dbConexion = new ClienteDao();
            List<Cliente> listaCliente =  dbConexion.Buscar(id);
            
   
            txtNombre.Text = listaCliente[0].Nombre.ToString();
            txtApellido.Text = listaCliente[0].Apellido.ToString();
            txtEdad.Text = listaCliente[0].Edad.ToString();
            txtEmail.Text = listaCliente[0].Email.ToString();
            txtTel.Text = listaCliente[0].Tel.ToString();
            cbEstado.Checked = listaCliente[0].Estado;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ClienteDao dbConexion = new ClienteDao();
            Cliente clienteActualizado = new Cliente();


            clienteActualizado.Id = id;
            clienteActualizado.Nombre = txtNombre.Text;
            clienteActualizado.Apellido = txtApellido.Text;
            clienteActualizado.Edad = Int32.Parse(txtEdad.Text);
            clienteActualizado.Email = txtEmail.Text;
            clienteActualizado.Tel = txtTel.Text;
            clienteActualizado.Estado = cbEstado.Checked;

            dbConexion.Actualizar(clienteActualizado);
            MessageBox.Show("El cliente fue actualizado con exito!");
        }
    }
}
