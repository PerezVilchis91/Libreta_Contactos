using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Libreta_Contactos
{
    class Contactos
    {
        private int id;
        private string nombre;
        private string correo;
        private string telefono;
        private string tipo;

        SqlConnection cn=new SqlConnection("Data Source=DESKTOP-G0D75RD;Initial Catalog=BD_Contactos;Integrated Security=True;TrustServerCertificate=True");

        public Contactos(string nombre, string correo, string telefono, string tipo)
        {
            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
            this.tipo = tipo;
        }
        public Contactos()
        {

        }
        public int AgregarContacto()
        {
            cn.Open();
            SqlCommand consulta = new SqlCommand("INSERT INTO tb_contactos " +
                "VALUES (@nombre,@correo,@telefono,@tipo)",cn);
            consulta.Parameters.AddWithValue("nombre",nombre);
            consulta.Parameters.AddWithValue("correo",correo);
            consulta.Parameters.AddWithValue("telefono",telefono);
            consulta.Parameters.AddWithValue("tipo",tipo);
            int FilasAfectadas=consulta.ExecuteNonQuery();
            cn.Close();

            return FilasAfectadas;
        }
        public void CargarContactos(DataGridView dtg)
        {
            string consulta = "SELECT * FROM tb_contactos";
            cn.Open();
            SqlDataAdapter data = new SqlDataAdapter(consulta,cn);
            DataTable dtn = new DataTable();
            data.Fill(dtn);
            dtg.DataSource = dtn;
        }
    }
}
