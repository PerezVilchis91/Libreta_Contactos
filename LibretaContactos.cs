using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libreta_Contactos
{
    public partial class dtgContactos : Form
    {
        public dtgContactos()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre=txtNombre.Text;
            string correo=txtCorreo.Text;
            string telefono=txtTel.Text;
            string tipo=cmbTipo.Text;

            if(nombre=="" || correo=="" || telefono=="" || tipo== "SELECCIONE TIPO")
            {
                MessageBox.Show("debe completar todos los campos");
            }
            else
            {
                Contactos NuevoContacto = new Contactos(nombre,correo,telefono,tipo);
                int fila= NuevoContacto.AgregarContacto();

                if (fila ==1) 
                {
                    MessageBox.Show("El registro se agrego correctamente");

                    txtNombre.Text = "";
                    txtCorreo.Text = "";
                    txtTel.Text = "";
                    cmbTipo.Text = "SELECCIONE TIPO";
                }
                else
                {
                    MessageBox.Show("Ocurrio un problema al agregar un registro" +
                       "Error" + MessageBoxButtons.OK + MessageBoxIcon.Warning);
                }
            }
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgContactos_Load(object sender, EventArgs e)
        {
            Contactos contacto = new Contactos();
            contacto.CargarContactos(dtgContacto);
        }

        private void dtgContacto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNombre.Text=dtgContacto.SelectedCells[1].Value.ToString();
            txtCorreo.Text = dtgContacto.SelectedCells[2].Value.ToString();
            txtTel.Text = dtgContacto.SelectedCells[3].Value.ToString();
            cmbTipo.Text = dtgContacto.SelectedCells[4].Value.ToString();
        }

        private void dtgContacto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
